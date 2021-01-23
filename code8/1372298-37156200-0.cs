      Task.Run(() => {
                while (!LogQueue.IsCompleted) {
                    logEntry LE;
                    LogQueue.TryTake(out LE, Timeout.Infinite);
                    
                    try {
                        ProcessLogEntry(LE);
                    } finally {
                       // Do nothing, because if logging cause issue, logging exception is likely to do so as well...
                    }
                }
                //functions.Logger.log("Exiting Queue Task", "LOGPROCESSING", LOGLEVEL.ERROR); // Will not work if exiting Q
            });
