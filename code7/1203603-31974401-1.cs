        public void MyCallingMethod()
        {
            CancellationToken csl = new CancellationToken();
            var threads = Enumerable.Range(0, 4).Select(p =>
                {
                    var t = new Thread(_ =>
                        {
                            Task.Factory.StartNew(() => MethodA(), csl, TaskCreationOptions.None,
                                new LimitedConcurrencyLevelTaskScheduler(1)).Wait();
                        });
					t.Start();	
                    return t;
                }).ToArray();
            //You can block the main thread and wait for the other threads here...
        }
