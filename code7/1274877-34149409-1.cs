    public class MyForm
    {
        private CancellationTokenSource cts = new CancellationTokenSource();
        private Task task;
        private void buttonStart_Click(object sender, EventArgs e) 
        {
            buttonStart.Enabled = false;
            buttonCancel.Enabled = true;
            
            task = Task.Factory.StartNew(() => {
                // do something extremely slow
                // and use 'ThrowIfCancellationRequested'
                for (int i = 0; i < Int32.MaxValue; i++)
                {
                    Thread.Sleep(10);
                    cts.Token.ThrowIfCancellationRequested();
                }
            }, cts.Token).ContinueWith(t => {
                if (t.IsCanceled)
                {
                    // User has cancelled loading
                }
                if (t.IsFaulted)
                {
                    // Exception has occured during loading
                }
                if (t.IsCompleted)
                {
                    // Loading complete
                }
            });
        }       
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
            buttonCancel.Enabled = false;
       
            cts.Cancel();
        }
    }
