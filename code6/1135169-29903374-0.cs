    using System;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    public class Program
    {
        public static void Main()
        {
            string label = "Art. 120 - Incapacità di intendere o di volere";
            JObject j = new JObject();
            j.Add(new JProperty("x", label));
            string s = j.ToString();
            var sr = new StringWriter();
            var jsonWriter = new JsonTextWriter(sr) {
                StringEscapeHandling =  StringEscapeHandling.EscapeNonAscii
            };
            new JsonSerializer().Serialize(jsonWriter, j);
            Console.Out.WriteLine(sr.ToString());
        }
    }
