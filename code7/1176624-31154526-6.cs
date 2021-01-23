        static CancellationTokenSource cts;
        static Task t;
        private void Method()
        {
            while (!cts.IsCancellationRequested) 
            {
                 // your logic here
            }
            t = null;
        }
        private void stdaq_click (object sender, EventArgs e)
        {           
           if(t != null) return;
           cts = new CancellationTokenSource();
           t = new Task(Method, cts.Token, TaskCreationOptions.None);
           t.Start();
        }
        private void spdaq_Click(object sender, EventArgs e) 
        {
           if(t != null) cts.Cancel(); 
        }
