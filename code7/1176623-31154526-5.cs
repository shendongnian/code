        static CancellationTokenSource cts = new CancellationTokenSource();
        static Task t;
        private void Method()
        {
            while (!cts.IsCancellationRequested) 
            {
                 // your logic here
            }
        }
        private void stdaq_click (object sender, EventArgs e)
        {
           if(t != null) return;
           t = new Task(Method, cts.Token, TaskCreationOptions.None);
           t.Start();
        }
        private void spdaq_Click(object sender, EventArgs e) 
        {
           cts.Cancel(); 
        }
