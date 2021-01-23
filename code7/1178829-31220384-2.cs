        static object glock = new object();
        private void button1_Click(object sender, EventArgs e)
        {
            using (BackgroundWorker w1 = new BackgroundWorker())
            {
                w1.DoWork += (s, we) => 
                {
                    lock (glock)
                    {
                        //Some computation 
                        we.Result = 1;
                    }
                };
                w1.RunWorkerAsync();
            }
            using (BackgroundWorker w2 = new BackgroundWorker())
            {
                w2.DoWork += (s, we) =>
                {
                    lock (glock)
                    {
                        //Some computation  
                        we.Result = 2;
                    }
                };
                w2.RunWorkerAsync();
            }
        }
