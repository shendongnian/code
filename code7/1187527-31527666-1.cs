        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {                
            while(commands.Count>0)
            {
                ICommandExecutor cmd = commands.Dequeue();
                try
                {
                    cmd.Execute();
                    // dispose if we can
                    IDisposable sync = cmd as IDisposable;
                    if (sync != null)
                    {
                        sync.Dispose();
                    }
                }
                catch(Exception exp)
                {
                    // add commands here
                    Trace.WriteLine("error" + exp.Message);
                }
            }   
        }
