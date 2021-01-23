            this.Deactivate += new EventHandler((a, b) => ThreadPool.QueueUserWorkItem((obj) =>
            {
                if (!Monitor.TryEnter(deactivateLockObject))
                    return;                
                try
                {
                    int count = 0;
                    int interval = 200;
                    while (count < 60000)
                    {
                        IntPtr foregroundWindowHandle = CSUTIL.GetForegroundWindow();
                        if (foregroundWindowHandle.ToString() != "0")
                        {
                            uint currentForegroundThreadId = CSUTIL.GetWindowThreadProcessId(foregroundWindowHandle, IntPtr.Zero);
                            if (new uint[] { threadidW1,threadidW2,threadidW3,etc. }.All((currentThreadId) => { return currentThreadId != currentForegroundThreadId; }))
                            {
                                // do the work on the gui thread
                                this.Invoke(new Action(this.MakeInvisible)); // Executes the closing & cleanup routine
                            }
                            return;
                        }
                        count += interval;
                        Thread.Sleep(interval);
                    }
                    this.Invoke(new Action(this.HandleSevereError));
                }
                finally
                {
                    Monitor.Exit(deactivateLockObject);
                }
            }));
