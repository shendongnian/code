    myTask = Task.Factory.StartNew(() => 
            {
                Console.Writeline("Task Started");
                do{
                    checkMatches(tokenSrc.Token);
                    Thread.Sleep(10); // Some pause to stop your code from going as fast as it possibly can and putting your CPU usage to 100% (or 100/number of cores%)
                }while(tokenSrc.IsCancellationRequested != true);
                Console.Writeline("Task Stopped");
            }
