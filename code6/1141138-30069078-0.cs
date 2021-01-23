    Task.Factory.StartNew(() =>
                {
                    bwAnalyzer.RunWorkerAsync(); //#1
                    autoReset.WaitOne(); //when commented working properly
                    Console.WriteLine("click"); //#4
                });
