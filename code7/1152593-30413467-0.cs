    namespace ConsoleApplication1
    {
        class Program
        {
            static bool Match(string pattern, string toMatch)
            {
                Dictionary<char, int> patternMap = new Dictionary<char, int>();
                Dictionary<char, int> toMatchMap = new Dictionary<char, int>();
    
                foreach (char ch in pattern)
                {
                    if (patternMap.ContainsKey(ch))
                        ++patternMap[ch];
                    else
                        patternMap[ch] = 1;
                }
                foreach (char ch in toMatch)
                {
                    if (toMatchMap.ContainsKey(ch))
                        ++toMatchMap[ch];
                    else
                        toMatchMap[ch] = 1;
                }
    
                foreach (var item in toMatchMap)
                {
                    if (!patternMap.ContainsKey(item.Key) || patternMap[item.Key] < item.Value)
                        return false;
                }
                return true;
            }
            static void Main(string[] args)
            {
                string pattern = "library";
                string[] test = { "lib", "rarlib", "rarrlib", "ll" };
                foreach (var item in test)
                {
                    if(Match(pattern, item))
                        Console.WriteLine("Match item : {0}", item);
                    else
                        Console.WriteLine("Failed item : {0}", item);
                }
                Console.ReadKey();
    
                /*
    Match item : lib
    Match item : rarlib
    Failed item : rarrlib
    Failed item : ll
    
                 */
            }
        }
    }
