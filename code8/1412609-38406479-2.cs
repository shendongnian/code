    overrride void ProcessRecord() {
        Task longRunningOperation;
        using(BlockingCollection<ProgressRecord> queue = new BlockingCollection<ProgressRecord>()) {
            //offload LongRunningOperation to different thread to keep control on PowerShell pipeline thread
            longRunningOperation=Task.Run(() => {
                try {
                    //replace EventHandler<ProgressChangeEventArgs> with ProgressChanged type
                    EventHandler<ProgressChangeEventArgs> handler =
                        //implemented as anonymous method to capture queue local variable
                        (object sender, ProgressChangeEventArgs e) => {
                            ProgressRecord progress = new ProgressRecord(activityId: 1, activity: "Moving data", statusDescription: "Current operation");
                            progress.PercentComplete = e.ProgressPercentage;
                            //queue ProgressRecord for processing in PowerShell pipeline thread
                            queue.Add(progress);
                        }
                    LongRunningOperation op = new LongRunningOperation();
                    op.ProgressChanged += handler;
                    op.Execute();
                    op.ProgressChanged -= handler;
                } finally {
                    queue.CompleteAdding();
                }
            });
            //event loop
            for(;;) {
                ProgressRecord progress;
                if(!queue.TryTake(out progress, Timeout.Infinite)) {
                    break;
                }
                WriteProgress(progress);
            }
        }
        //get any exception from LongRunningOperation
        longRunningOperation.GetAwaiter().GetResult();
    }
