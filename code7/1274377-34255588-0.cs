    class Test
    {
        private readonly object _gettingDataTaskLock = new object();
        private Task<int> _gettingDataTask;
        public int GetData(int credential)
        {
            Task<int> inProgressDataTask = null;
            Console.WriteLine(credential + "-TEST0");
            lock (_gettingDataTaskLock)
            {
                Console.WriteLine(credential + "-TEST1");
                if (_gettingDataTask == null)
                {
                    Console.WriteLine(credential + "-TEST2");
                    _gettingDataTask = Task.Factory.StartNew(()
                        => GetDataInternal(credential));
                    _gettingDataTask.ContinueWith((task) =>
                    {
                        lock (_gettingDataTaskLock)
                        {
                            Console.WriteLine(credential + "-TEST3");
                            _gettingDataTask = null;
                            Console.WriteLine(credential + "-TEST4");
                        }
                    },
                        TaskContinuationOptions.ExecuteSynchronously);
                    Console.WriteLine(credential + "-TEST5");
                }
                //_gettingDataTask.Wait();
                Console.WriteLine(credential + "-TEST6");
                inProgressDataTask = _gettingDataTask;
                Console.WriteLine(credential + "-TEST7");
            }
            Console.WriteLine(credential + "-TEST8");
            try
            {
                Console.WriteLine(credential + "-TEST9");
                return inProgressDataTask.Result;
            }
            catch (AggregateException ex)
            {
                throw ex.InnerException;
            }
        }
        private int GetDataInternal(int credential)
        {
            return credential;
        }
    }
