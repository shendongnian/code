     private static async Task merge(Func<ConcurrentDictionary<string,int>> getter, Action<ConcurrentDictionary<string,int>> setter, List<parserPart>list)
            {
                List<Task> tasks  = new List<Task>();
                var target = getter();
                int buffer;
                foreach (parserPart b in list)
                {
                    tasks.Add(Task.Factory.StartNew( () => {
                        target.TryGetValue(b.uploader_id, out buffer);
                        target.TryAdd(b.uploader_id, (buffer + b.count));
                    }
                }
                Task.WaitAll(tasks.ToArray()); 
                await Task.Run(() => setter(target));
                Console.Writeline("merging task");
            }
        }
