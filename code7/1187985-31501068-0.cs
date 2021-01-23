       private void Start_Stop_Click(object sender, EventArgs e)
       {
            // gets context of current UI thread (to update smth later using it)
            SynchronizationContext cont = SynchronizationContext.Current;
            // starts hot task with your logic
            Task.Factory.StartNew(() =>
            {                                
                 double x = 0;
                 while (true)
                 {
                    x = x + 0.05;
                    // this operation will be executed on UI thread with use of sync context
                    cont.Post(delegate { y.Text = x.ToString(); }, null);                
                    Thread.Sleep(100);
                 }
            });
        }
