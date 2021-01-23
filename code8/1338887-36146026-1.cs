    static void Main(string[] args)
            {
                //string[] str1 = { "this", "is", "a simple", "text", "for", "example", "." };
                //string[] str2 = { "this", "is", "a", "simple text", "for", "example", "." };
                //string[] tag1 = { "tt", "ii", "aa", "ttt", "ff", "ee", "pp" };
                //string[] tag2 = { "tt", "ii", "aa", "aa", "ff", "ee", "pp" };
    
                //string[] str1 = { "this", "is", "a simple", "text", "for", "this", "example", "." };
                //string[] str2 = { "this", "is", "a", "simple text", "for", "this example", "." };
                //string[] tag1 = { "tt", "ii", "aa", "ttt", "ff","tttt", "ee", "pp" };
                //string[] tag2 = { "tt", "ii", "aa", "aa", "ff", "tttt", "pp" };
    
                string[] str1 = { "this", "is", "a simple", "text", "for", "this", "example", "." };
                string[] str2 = { "this", "is", "a", "simple text", "for", "this example", "." };
                string[] tag1 = { "tt", "ii", "aa", "ttt", "ff", "tt", "ee", "pp" };
                string[] tag2 = { "tt", "ii", "aa", "aa", "ff", "tt", "pp" };
    
                Dictionary<string, string> map = new Dictionary<string, string>();
                Dictionary<string, int> wordIndexDict = new Dictionary<string, int>();
                for (int i = 0; i < str1.Length; i++)
                {
                    string word = str1[i];
                    string tag = tag1[i];
                    string[] words = word.Split();
                    foreach (var item in words)
                    {
                        int cnt = 1;
                        if (wordIndexDict.ContainsKey(item))
                        {
                            cnt = wordIndexDict[item];
                            wordIndexDict[item] = cnt + 1;
                            cnt = cnt + 1;
                        }
                        else {
                            wordIndexDict.Add(item, cnt);
                        }
                        map.Add(item + "_" + cnt, tag);
    
                    }
                }
    
                wordIndexDict = new Dictionary<string, int>();
    
                List<string> output = new List<string>();
                for (int i = 0; i < str2.Length; i++)
                {
                    string word = str2[i];
                    string[] words = word.Split();
    
                    int cnt = 1;
                    if (wordIndexDict.ContainsKey(words[0]))
                    {
                        cnt = wordIndexDict[words[0]];
                        wordIndexDict[words[0]] = cnt + 1;
                        cnt = cnt + 1;
                    }
                    else {
                        wordIndexDict.Add(words[0], cnt);
                    }
                    string key = words[0] + "_" + cnt;
                    if (map.ContainsKey(key))
                    {
                        string tag = map[key];
                            output.Add(tag);
                    }
                }
    
                foreach (var item in output)
                {
                    Console.WriteLine(item);
                }
                
                Console.ReadKey();
            }
