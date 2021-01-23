    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var json = "{ 'A': 'A0' , 'B' : { 'B2' : 'B2 - Val', 'B3' : [{'B30' : 'B30 - Val1' ,'B31' : 'B31 - Val1'}]}, 'C': ['C0', 'C1']}";
                var jss = new JavaScriptSerializer();
                var dictionaryEntries = jss.Deserialize<Dictionary<string, object>>(json);
    
                List<string> columns = new List<string>();
                GetColumnsFromJsonDictionary(columns, dictionaryEntries);
    
                Console.WriteLine("List of columns");
                Console.WriteLine("===============");
                columns.ForEach(col => Console.WriteLine(col));
                Console.ReadKey();
            }
    
    
            private static void GetColumnsFromJsonDictionary(List<string> columns, Dictionary<string, object> dictionary)
            {
                if (dictionary == null) return;
    
                foreach (var kvp in dictionary)
                {
                    if (kvp.Value.GetType() == typeof(Dictionary<string, object>))
                    {
                        var subDictionary = kvp.Value as Dictionary<string, object>;
    
                        // Recurse hierarchy 
                        GetColumnsFromJsonDictionary(columns, subDictionary);
                    }
                    else if (kvp.Value.GetType() == typeof(System.Collections.ArrayList))
                    {
                        var arr = kvp.Value as System.Collections.ArrayList;
                        if (arr[0].GetType() == typeof(String))
                            columns.Add(kvp.Key);
    
                        foreach (var entry in arr)
                        {
                            var subArrDictionary = entry as Dictionary<string, object>;
    
                            // Recurse hierarchy 
                            GetColumnsFromJsonDictionary(columns, subArrDictionary);
                        }
                    }
                    else if (kvp.Value.GetType() == typeof(String))
                    {
                        columns.Add(kvp.Key);
                    }
                    else
                    {
                        throw new NotSupportedException(string.Format("Type '{0}' not supported", kvp.Value.GetType().ToString()));
                    }
    
                }
            }
        }
    }
