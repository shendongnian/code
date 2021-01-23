     private IEnumerable<object> GetEntitiesInParallel(Type type, string apiPath, Dictionary<string, string> parameters, int startPosition, int maxAmount)
             {
                 var context = new TaskThreadingContext(maxAmount, startPosition);
                 var threads = Enumerable.Range(0, NumberOfThreads).Select(i =>
                 {
                     var task = Task.Factory.StartNew(() =>
                     {
                         while (context.Continue)
                         {
                             var rawData = String.Empty;
                             var offset = context.NextAmount();
                             var result = GetEntitiesSingleRequest(type, parameters, offset, apiPath, out rawData);
                             if (result.Any())
                             {
                                 context.AddResult(result.Cast<object>(), rawData);
                             }
                             else
                             {
                                 context.NoResult();
                             }
                         }
                     });
    
                     return task;
                 }).ToArray();
    
                 Task.WaitAll(threads);
    
                 var results = context.GetResults<object>();
                 return results;
             }
    
    
            private IEnumerable<object> GetEntitiesSingleRequest(Type type,Dictionary<string,string> parameters,
                int offset,string apiPath, out string rawData)
            {
                var request = Utility.CreateRestRequest(apiPath, Method.GET,ApiKey,50,offset,parameters);
                
                type = typeof(List<>).MakeGenericType(type);
                var method = Client.GetType().GetMethods().Single(m => m.IsGenericMethod && m.Name == "Execute").MakeGenericMethod(type);
                try
                {
                    dynamic response = (IRestResponse)method.Invoke(Client, new object[] { request });
                    var data = response.Data as IEnumerable;
                    var dataList = data.Cast<object>().ToList();
                    rawData = response.Content.Replace("\n", Environment.NewLine);
                    return dataList.OfType<object>().ToList();
    
                }
                catch (Exception ex)
                {
                    if (ex.Message.IndexOf("404") != -1)
                    {
                        rawData = null;
                        return Enumerable.Empty<object>();
                    }
                    throw;
                }
            }
            private class TaskThreadingContext
            {
                private int batchAmount = 50;
                private object locker1 = new object();
                private object locker2 = new object();
                private CancellationTokenSource tokenSource;
                private CancellationToken token;
                private volatile bool cont = true;
                private volatile int offset = 0;
                private volatile int max = 0;
                private volatile int start = 0;
                private List<object> result = new List<object>();
                private List<string> raw = new List<string>();
                public bool Continue { get { return cont; } }
    
    
    
                public TaskThreadingContext(int maxRows = 0,int startPosition = 0)
                {
                    max = maxRows;
                    offset = start = startPosition;
                   
                }
    
                public int NextAmount()
                {
                    lock(locker1)
                    {
                        var ret = offset;
                        var temp = offset + batchAmount;
                        if (temp - start > max && max > 0)
                        {
                            temp = max - offset;
                        }
                        offset = temp;
                        if (offset - start >= max && max > 0)
                        {
                            cont = false;
                        }
                        return ret;
                    }
                }
    
                public TaskThreadingContext()
                {
                    tokenSource = new CancellationTokenSource();
                    token = tokenSource.Token;
                }
    
                public void AddResult(IEnumerable<object> items,string rawData)
                {
                    lock(locker2)
                    {
                        result.AddRange(items);
                        raw.Add(rawData);
                    }
                }
    
                public IEnumerable<T> GetResults<T>()
                {
                    return this.result.Cast<T>().ToList();
                }
    
                public void NoResult()
                {
                    cont = false;
                }
    
           }
