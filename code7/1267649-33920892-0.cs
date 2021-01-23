    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.Security;
    using System.Web.SessionState;
     
    namespace AspNetBackgroundProcess
    {
        public static BackgroundWorker worker = new BackgroundWorker()
        public static bool stopWorker = false;
        public class Global : System.Web.HttpApplication
        {
            protected void Application_Start(object sender, EventArgs e)
            {
                worker.DoWork += new DoWorkEventHandler(DoWork);
                worker.WorkerReportsProgress = true;
                worker.WorkerSupportsCancellation = true;
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkerCompleted);
                // Calling the DoWork Method Asynchronously
                worker.RunWorkerAsync();
            }
            protected void Application_End(object sender, EventArgs e)
            {
                if (worker != null)
                    worker.CancelAsync();
            }
     
             //Start Process
            private void button1_Click(object sender, EventArgs e)
            {
                worker.RunWorkerAsync();
            }
        
            //Cancel Process
            private void button2_Click(object sender, EventArgs e)
            {
                 //Check if background worker is doing anything and send a cancellation if it is
                if (worker.IsBusy)
                {
                    worker.CancelAsync();
                }
        
            }
            private static void DoWork(object sender, DoWorkEventArgs e)
            {
                decimal cycleCount = ProductCount / batchSize; //Depending on where you get these variables, you might consider moving this to the class level along with the other variable declarations
                for (int i = 0; i <= Math.Round(cycleCount); i++)
                {
                    //Check if there is a request to cancel the process
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        worker.ReportProgress(0);
                        return;
                    }
       
                    var Products = Products(batchSize, languageId, storeId).ToList();
                    solrCustomWorker.Add(solrProducts);
                    solrCustomWorker.Commit();
                }
            }
            private static void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                if (worker != null)
                {
                    System.Threading.Thread.Sleep(3000);
                    if (!stopWorker)
                    {
                        worker.RunWorkerAsync();
                    }
                    else
                    {
                        while (stopWorker)
                        {
                            Thread.Sleep(6000);
                        }
                        worker.RunWorkerAsync();
                    }
                }
            }
        }
    }
