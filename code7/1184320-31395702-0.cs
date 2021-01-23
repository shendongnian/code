        private void button1_Click(object sender, EventArgs e)
        {
            HtmlDocument doc = web.Document;
            m_oWorker.RunWorkerAsync(doc);
        }
        void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            HtmlDocument doc = (HtmlDocument)e.Argument;
            //NOTE : Never play with the UI thread here...
            string line;
            //time consuming operation
            while ((line = sr.ReadLine()) != null)
            {
                int index = line.IndexOf(":");
                
                Thread.Sleep(1000);
                m_oWorker.ReportProgress(cnt);
                //If cancel button was pressed while the execution is in progress
                //Change the state from cancellation ---> cancel'ed
                if (m_oWorker.CancellationPending)
                {
                    e.Cancel = true;
                    m_oWorker.ReportProgress(0);
                    return;
                }
                cnt++;
            }
            //Report 100% completion on operation completed
            m_oWorker.ReportProgress(100);
        }
