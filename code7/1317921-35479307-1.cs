        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication11
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                string JSONIncludeBackslash = "{\"foo1\":{\"0\":\"0\",\"2\":\"S\",\"3\":\"J\",\"4\":\"Q\",\"5\":\"X\",\"6\":\"M\"},\"foo2\":{\"1\":\"one\",\"7\":\"seven\",\"8\":\"eight\"}}";
                Dictionary<string, string> JSONDictionary = JSONIncludeBackslash.Replace("\"", "").Replace(":{", "*").Replace("},", ",").Replace("}}", "").Replace("{", "").Replace("}", "").Split(',').ToDictionary(value => { return value.Split(':')[0].IndexOf("*") > -1 ? value.Split(':')[0].Split('*')[1] : value.Split(':')[0]; });
    
                Dictionary<string, string> JSONDictionary1 = JSONIncludeBackslash.Replace("\"", "").Replace(":{", "*").Replace("},", ",").Replace("}}", "").Replace("{", "").Replace("}", "").Split(',').ToDictionary(value => { return value.Split(':')[0].IndexOf("*") > -1 ? value.Split(':')[0].Split('*')[1] : value.Split(':')[0]; });
                foreach (var Entry in JSONDictionary1)
                {
                    JSONDictionary[Entry.Key] = Entry.Value.Split(':')[1];
                }
    
                IList<KeyValuePair<string, string>> JSONList = JSONDictionary.ToList();
                foreach (var Item in JSONList)
                {
                    Console.WriteLine(Item);
                }
                Console.ReadLine();
            }
        }
    }
