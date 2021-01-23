    using System.IO;
    using System;
    using System.Text;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
             List<Tuple<string, string>> values = new List<Tuple<string, string>>();
             values.Add(new Tuple<string, string>("One", "Value 1"));
             values.Add(new Tuple<string, string>("Two", "Value x"));
             values.Add(new Tuple<string, string>("One", "Value 10"));
             Console.Write(Format.ToJson(values));
        }
    }
    
    static class Format {
        public static string ToJson(List<Tuple<string, string>> values) {
            StringBuilder builder = new StringBuilder();
            foreach(var item in values) {
                builder.Append(string.Format("{{{0}:{1}}},", item.Item1, item.Item2));
            }
            return "{" + builder.ToString() + "}";
        }
    }
