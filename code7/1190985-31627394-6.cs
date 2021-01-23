        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while(!this.IsDisposed)
            {
                // if we have animations
                while(Animations.List.Count > 0)
                {
                    // iterate over all of them
                    foreach(var command in Animations.List)
                    {
                        // switch to the UI thread, passing our command
                        backgroundWorker1.ReportProgress(42, command);
                    }
                    Thread.Sleep(30); // every 30ms approx 30fps
                }
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // get our command so we can execute
            // notice that command is actually an AnimateButton instance
            ICommandExecutor command = (ICommandExecutor)e.UserState;
            command.Execute();
        }
