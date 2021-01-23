    static void Main(string[] args)
            {
                string[] str1 = { "this", "is", "a simple", "text", "for", "example", "." };
                string[] str2 = { "this", "is", "a", "simple text", "for", "example", "." };
                string[] tag1 = { "tt", "ii", "aa", "ttt", "ff", "ee", "pp" };
                ///getting tag2 array is the desired result:
                string[] tag2 = { "tt", "ii", "aa", "aa", "ff", "ee", "pp" };
    
                Dictionary<string, string> map = new Dictionary<string, string>();
                for (int i = 0; i < str1.Length; i++)
                {
                    string word = str1[i];
                    string tag = tag1[i];
                    string[] words = word.Split();
                    foreach (var item in words)
                    {
                        map.Add(item, tag);
    
                    }
                }
    
                List<string> output = new List<string>();
                for (int i = 0; i < str2.Length; i++)
                {
                    string word = str2[i];
                    string[] words = word.Split();
                    if (map.ContainsKey(words[0]))
                    {
                        string tag = map[words[0]];
                            output.Add(tag);
                    }
                }
    
                foreach (var item in output)
                {
                    Console.WriteLine(item);
                }
                
                Console.ReadKey();
            }
