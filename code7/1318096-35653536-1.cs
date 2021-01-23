     bool canDoHardWork = true;
     private void dataGridView1_SelectionChanged(object sender, EventArgs e)
            {
                if (canDoHardWork)
                {
                    int interval = 2000; // Just 2 seconds
                    Task.Factory.StartNew(() =>
                    {
                        canDoHardWork= false;
                        Thread.Sleep(interval);
                        this.BeginInvoke((Action)(() =>
                        {                         
                            PopulateTabs(); // Very hard work
                            dataGridView1.Focus();
                            canDoHardWork= true;
                        }), null);
    
                    });
                }
            }
