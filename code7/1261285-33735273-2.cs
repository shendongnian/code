          /*using System;
          using System.IO;
          using System.IO.Compression;
          using System.Net.Http;
          using System.Net.Http.Headers;
          using System.Text;
          using Newtonsoft.Json;
          using WebApi.Models;*/
    
     class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to POST");
            Console.ReadLine();
            RemotePush(new BlockList());
            Console.ReadLine();
        }
        public static async void RemotePush(BlockList blocks)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        Console.WriteLine("Please wait.");
                        client.BaseAddress = new Uri("http://localhost:52521/Home/"); 
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var content = JsonCompress(blocks);
                        var response = await client.PostAsync("SyncPush/", content);
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            using (var streamReader = new StreamReader(stream))
                            {
                                Console.WriteLine(streamReader.ReadToEnd());
                            }
                        }
                        Console.WriteLine("Done.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static MultipartFormDataContent JsonCompress(object data)
        {
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
            var stream = new MemoryStream();
            using (var zipper = new GZipStream(stream, CompressionMode.Compress, true))
            {
                zipper.Write(bytes, 0, bytes.Length);
            }
            MultipartFormDataContent multipartContent = new MultipartFormDataContent();
            multipartContent.Add(new StreamContent(stream), "gzipContent");
            return multipartContent;
        }
    }
