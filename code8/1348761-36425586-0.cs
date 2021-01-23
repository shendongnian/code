    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string pattern = "(?'name'[^:]):(?'value'.*)";
                string input = "user:jim;id:23;group:49st";
                Dictionary<string,string> dict = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(x => new
                {
                    name = Regex.Match(x, pattern).Groups["name"].Value,
                    value = Regex.Match(x, pattern).Groups["value"].Value
                }).GroupBy(x => x.name, y => y.value)
                .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                dict["group"] = "76pm";
                string output = string.Join(";",dict.AsEnumerable().Select(x => string.Join(":", new string[] {x.Key, x.Value})).ToArray());
            }
        }
    }
