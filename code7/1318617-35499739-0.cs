         private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerSupportsCancellation = true;            
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            button1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }
    
        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Invoke((MethodInvoker)delegate { button1.Enabled = true; });
            backgroundWorker1.DoWork -= backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted -= backgroundWorker1_RunWorkerCompleted;
        }
    
        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);                
                AppendTextBox( "Hit: " + i.ToString() + Environment.NewLine);
                if (backgroundWorker1.CancellationPending)
                {
                    break;
                }
            
            }
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
            }            
        }
        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            textBox1.Text += value;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync(); 
        }
