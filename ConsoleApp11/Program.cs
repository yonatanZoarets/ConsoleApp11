using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ConsoleApp7
{
  
    class Program
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Boolean succeed = false;
            string iterations = "";
            int iterationsInt = 0;
            Console.WriteLine("Enter A Number: ");
            while (succeed == false)
            {
                iterations = Console.ReadLine();
                try
                {
                    iterationsInt = Convert.ToInt32(iterations);
                    succeed = true;
                }
                catch { }
            }//make sure int entered

            stopwatch.Start();//start at the starting
            for (int i = 0; i < iterationsInt; i++)
            {
                //do nothing - in the task not writen to do something every iteration
            }
            stopwatch.Stop();
            TimeSpan sw = stopwatch.Elapsed;//finishing exactly at the end of the loop
            string elapsedTime = String.Format("{0:0.0} ms", sw.TotalMilliseconds);//as you asked the miliseconds
            Console.WriteLine("Time " + elapsedTime);
            DateTime thisDay = DateTime.Today;
            string today = thisDay.ToString("d");
            try
            {
                log.Info(today + "-Input:" + iterations + "-Time:" + elapsedTime+"\n");//writing to the file 
            }//and also printing the time from the log4net, together wit the rest
            catch (Exception ex)
            {
                log.Debug("Debug error logging", ex);
                log.Info("Info error logging", ex);
                log.Warn("Warn error logging", ex);
                log.Error("Error error logging", ex);
                log.Fatal("Fatal error logging", ex);
            }
            
            Console.ReadLine();//watch the amount of time printed out, and click something to finish the program


            //thats without log4net, if relevant(if yes it might be without connection of the app.config to the file path):

            //string myDirectory = @"C:\Users\Ronit.Iconics\source\repos";//here is my directory, change here if you need to get the file in your computer
            //string path = @"\ConsoleApp11\ConsoleApp11\MyFirstLog.txt";//this is the full path
            //if (File.Exists(myDirectory + path))
            //{
            // //Writing to the existing file
            //using (StreamWriter sw = new StreamWriter(myDirectory + path, append: true))
            //{
            //sw.WriteLine(today + "-Input:" + iterations + "-Time:" + elapsedTime);
            //}
            //}
        }
    }
}
