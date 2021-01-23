    public System.Threading.Tasks.Task<System.Collections.Generic.IDictionary<string, byte[]>> DownloadTask(System.Collections.Generic.IEnumerable<string> urlList)
            {
                return new System.Threading.Tasks.Task<System.Collections.Generic.IDictionary<string, byte[]>>(() =>
                {
                    var r = new System.Collections.Concurrent.ConcurrentDictionary<string, byte[]>();
                    System.Threading.Tasks.Parallel.ForEach<string>(urlList, (url, s, l) =>
                    {
                        using (System.Net.WebClient client = new System.Net.WebClient())
                        {
                            var bytedata = client.DownloadData(url);
                            r.TryAdd(url, bytedata);
                        }
                    });
                    
                    var results = new System.Collections.Generic.Dictionary<string, byte[]>();
                    foreach (var value in r)
                    {
                        results.Add(value.Key, value.Value);
                    }
                    return results;
                });
            }
