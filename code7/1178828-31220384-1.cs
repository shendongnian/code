        private void button1_Click(object sender, EventArgs e)
        {
            using (BackgroundWorker w1 = new BackgroundWorker())
            {
                w1.DoWork += (s, we) => 
                {
                    //Some computation                    
                    we.Result = 1;
                };
                w1.RunWorkerCompleted += (s, first) =>
                {
                    using (BackgroundWorker w2 = new BackgroundWorker())
                    {
                        w2.DoWork += (s2, we2) =>
                        {
                            //Some computation
                            we2.Result = 2;
                        };
                        w2.RunWorkerCompleted += (s2, second) =>
                            Console.WriteLine(first.Result.ToString() + second.Result.ToString());
                        w2.RunWorkerAsync();
                    }
                };
                w1.RunWorkerAsync();
            }
        }
