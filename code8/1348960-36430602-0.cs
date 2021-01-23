    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Net;
    using System.Data;
    using System.Collections.Concurrent;
    
    using System.Threading.Tasks;
    
    namespace ParseWebservices
    {
        static class UrlLoaderExtension
        {
            public static async Task<ConcurrentDictionary<string, string>> LoadUrls(this IEnumerable<string> urls)
            {
                var result = new ConcurrentDictionary<string,string>();                
                Task[] tasks = urls.Select(async url => {
                    using (WebClient wc = new WebClient())
                    {
                        try
                        {
                            var r = await wc.DownloadStringTaskAsync(url);
                            result[url] = r;
                        }
                        catch (Exception err)
                        {
                            result[url] = err.Message;
                        }
                    }
                }).ToArray();                
                await Task.WhenAll(tasks);
                return result;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var requests = new ConcurrentDictionary<string,string>();
    
                // load desired urls into the structure
                requests["http://www.microsoft.com"] = null;
                requests["http://www.google.com"] = null;
                requests["http://www.google.com/asdfdsaf"] = null;
    
                try
                {
                    Task.Run(async () =>
                    {
                        requests = await requests.Keys.LoadUrls();
                    }).GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.ReadLine();
                    return;
                }
    
                Console.WriteLine("Finished loading data concurrently");
                Console.ReadLine();
    
                // this part is synchronous (it's not waiting for IO)
                foreach(var url in requests.Keys)
                {
                    var response = requests[url];
                    Console.WriteLine(response); // 
                    Console.WriteLine("Response from " + url);
                    Console.ReadLine();
                }
                    
    
    
                Console.Write("DONE");
                Console.ReadLine();
            }
        }
    }
