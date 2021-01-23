    public void btnStart_Click(object sender, RoutedEventArgs e)
    {
        LaunchTasks();
    }
    private void LaunchTasks()
            {
                Task T;
                List<Task> TaskList = new List<Task>();
    
                LogtoStatusText("**** Begin creating tasks *****");
    
                s1.Start();
    
                AProject.FactorClassList.ForEach((f) =>
                {
                    T = new Task(((x) => { OnUIThread(() => { RunningTasks++; }); Factor(f); }), ct);
    
                    T.ContinueWith((y) =>
                    {
                        if (y.Exception != null)
                        {
                            // LogtoStatusText(y.Status + " with "+y.Exception.InnerExceptions[0].GetType()+": "+ y.Exception.InnerExceptions[0].Message);
                        }
                        if (!y.IsFaulted)
                        {
    
                            AProject.TotalProcessedAccounts++;
                            AProject.AverageProcessTime = (((Double)AProject.TotalProcessedAccounts / s1.ElapsedMilliseconds) * 1000);
                        }
                        OnUIThread(() => { RunningTasks--; });
                        OnUIThread(() => { UpdateCounts(AProject); });
    
    
                    });
    
                    TaskList.Add(T);
                });
    
                try
                {
                    Task.Factory.ContinueWhenAll(TaskList.ToArray(), (z) => { LogtoStatusText("**** Completed all Tasks *****"); OnUIThread(() => { UpdateCounts(AProject); }); });
                }
                catch (AggregateException a)
                {
                    // For demonstration purposes, show the OCE message.
                    foreach (var v in a.InnerExceptions)
                        LogtoStatusText("msg: " + v.Message);
                }
    
                LogtoStatusText("**** All tasks have been initialized, begin processing *****");
    
                TaskList.ForEach(t => t.Start());
            }
