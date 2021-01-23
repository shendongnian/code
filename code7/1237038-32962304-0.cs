    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.Serialization;
    using System.IO;
    using System.Net;
    using Newtonsoft.Json;
    
    namespace ConsoleApplication1
    {
      class Program
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                var url = "http://localhost:14596/api/values";
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers[HttpRequestHeader.Accept] = "application/json";
                byte[] result = client.DownloadData(url);
                // now use a JSON parser to parse the resulting string back to some CLR object
                string[] resultArr = parse(result);
            }
        }
        public static string[] parse(byte[] json)
        {
             string jsonStr = Encoding.UTF8.GetString(json);
                return JsonConvert.DeserializeObject<string[]>(jsonStr);
            }
        }
    }
