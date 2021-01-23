        public async Task<long> Execute(
            IStatement[] statements, int parallelism, int maxOutstandingRequests)
        {
            var semaphore = new SemaphoreSlim(maxOutstandingRequests);
            var tasks = new Task<RowSet>[statements.Length];
            var chunkSize = statements.Length / parallelism;
            if (chunkSize == 0)
            {
                chunkSize = 1;
            }
            var statementLength = statements.Length;
            var launchTasks = new Task[parallelism + 1];
            var watch = new Stopwatch();
            watch.Start();
            for (var i = 0; i < parallelism + 1; i++)
            {
                var startIndex = i * chunkSize;
                //start to launch in parallel
                launchTasks[i] = Task.Run(async () =>
                {
                    for (var j = 0; j < chunkSize; j++)
                    {
                        var index = startIndex + j;
                        if (index >= statementLength)
                        {
                            break;
                        }
                        await semaphore.WaitAsync();
                        var t = _session.ExecuteAsync(statements[index]);
                        tasks[index] = t;
                        var rs = await t;
                        semaphore.Release();
                    }
                });
            }
            await Task.WhenAll(launchTasks);
            await Task.WhenAll(tasks);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
