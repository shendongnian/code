    using System.Collections.Generic;
    namespace Test
    {
        class Program
        {
            static void Main()
            {
                Dictionary<string, Object> dictionary = new Dictionary<string, string>();
    
                dictionary.Add("cat", "one");
                dictionary.Add("dog", "two");
                dictionary.Add("llama", "three");
                dictionary.Add("iguana", "four");
    
                var test1 = GetWhatEver(dictionary, "llama");
                var test2 = GetWhatEver(dictionary, "llama");
                var test3 = GetWhatEver(dictionary, "llama");
            }
    
             static Object GetWhatEver(Dictionary<string, Object> dict, string key_to_find)
            {
                foreach (var kvp in dict)  
                {
                    if (kvp.Key == key_to_find)
                    {return kvp.Value;}
                }
                return null;
            }
    
        }
    }
