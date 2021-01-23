    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.Threading;
    
    namespace download_demo
    {
        class Program
        {
        
    
            static void Main(string[] args)
            {   
                BackgroundWorker MyWorker = new BackgroundWorker();
               MyWorker.DoWork += MyWorker_DoWork;
               MyWorker.RunWorkerCompleted +=MyWorker_RunWorkerCompleted;
               MyWorker.RunWorkerAsync();
               Console.ReadKey();
            }
    
            private static void MyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                Console.WriteLine("both job completed");
            }
    
            private static void MyWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                Thread download = new Thread(DownloadJob);
                download.Start();
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(20);
                    Console.WriteLine("doing some job while downloading ");
    
                }
                Console.WriteLine("waiting the end of download......... ");
                download.Join();
    
            }
    
            private static void DownloadJob(object path)
            {
               /// process download the path
               ///simulate 20 seconde of download
               for(int i = 0;i<100;i++)
               {
                   Thread.Sleep(50);
                   Console.WriteLine("downloaded :" + i + " Ko");
               }
            }
         
        }
    }
