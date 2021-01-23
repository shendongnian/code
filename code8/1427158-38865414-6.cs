    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    
    namespace DataflowTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var options = new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 4, EnsureOrdered = false };
                var firstBlock = new TransformBlock<int, string>(x => x.ToString(), options);
    
                var secondBlock = new TransformBlock<string, Tuple<string, string>>(async x =>
                {
                    using (var httpClient = new HttpClient())
                    {
                        if (x == "4") await Task.Delay(5000);
    
                        var result = await httpClient.GetStringAsync($"http://scooterlabs.com/echo/{x}");
                        return new Tuple<string, string>(x, result);
                    }
                }, options);
    
                var thirdBlock = new TransformBlock<Tuple<string, string>, Tuple<string, byte[]>>(x =>
                 {
                     using (var algorithm = SHA256.Create())
                     {
                         var bytes = Encoding.UTF8.GetBytes(x.Item2);
                         var hash = algorithm.ComputeHash(bytes);
    
                         return new Tuple<string, byte[]>(x.Item1, hash);
                     }
                 }, options);
    
                var fourthBlock = new ActionBlock<Tuple<string, byte[]>>(x =>
                {
                    var output = $"{DateTime.Now}: Hash for element #{x.Item1}: {GetHashAsString(x.Item2)}";
    
                    Console.WriteLine(output);
                }, options);
    
                firstBlock.LinkTo(secondBlock);
                secondBlock.LinkTo(thirdBlock);
                thirdBlock.LinkTo(fourthBlock);
    
                var populateTasks = Enumerable.Range(1, 10).Select(x => firstBlock.SendAsync(x));
                Task.WhenAll(populateTasks).ContinueWith(x => firstBlock.Complete()).Wait();
    
                fourthBlock.Completion.Wait();
            }
    
            private static string GetHashAsString(byte[] bytes)
            {
                var sb = new StringBuilder();
                int i;
                for (i = 0; i < bytes.Length; i++)
                {
                    sb.AppendFormat("{0:X2}", bytes[i]);
                    if (i % 4 == 3) sb.Append(" ");
                }
    
                return sb.ToString();
            }
        }
    }
