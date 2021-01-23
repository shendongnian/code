                        int pi = 0;    
                        var plist = new Task[pdList.Count];                        
                        foreach(var pd in pdList)
                        {
                            plist[pi++] = Task.Factory.StartNew(() => ExecuteProcess(pd, hargs), TaskCreationOptions.LongRunning);
                        }
    
                        Task.WaitAll(plist);
