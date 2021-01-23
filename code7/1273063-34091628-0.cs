        bool keepGoing = true;
        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(Work);
        }
        private void Work()
        {
            while (keepGoing)
            {
                try
                {
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
