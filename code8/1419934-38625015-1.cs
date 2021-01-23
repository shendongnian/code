        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            string dbgout = "";
            var startTime = DateTime.Now;
            dbgout += "BgTask ";
            var cost = BackgroundWorkCost.CurrentBackgroundWorkCost;
            var cancel = new System.Threading.CancellationTokenSource();
            taskInstance.Canceled += (s, e) =>
            {
                dumpLog("Canceled.");
                cancel.Cancel();
                cancel.Dispose();
            };
            try
            {
                _deferral = taskInstance.GetDeferral();
                dbgout += cost.ToString() + " ";
                switch (cost)
                {
                    case BackgroundWorkCostValue.Low:
                    case BackgroundWorkCostValue.Medium:
                        await TimeConsumedTaskLowMidAsync().AsTask(cancel.Token);
                        break;
                    case BackgroundWorkCostValue.High:
                        await TimeConsumedTaskHighAsync().AsTask(cancel.Token);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                dbgout += ("Failed " + e.Message + "...");
            }
            finally
            {
                dumpLog(dbgout + " " + (DateTime.Now - startTime).TotalSeconds.ToString("F1"));
                _deferral.Complete();
            }
        }
