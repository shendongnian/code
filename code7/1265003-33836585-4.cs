    class Program
    {
        static void Main(string[] args)
        {
            string pathCase1 = "Category A|Category A > Sub Category 1|Category B|Category C|Category C > Sub Category 2";
            string pathCase2 = "Category A -> THIS IS DATA IS REDUNDANT|Category A > Sub Category 1 -> THIS IS DATA IS REDUNDANT|Category A > Sub Category 1 > Sub Sub Category 1|Category A > Sub Category 1 > Sub Sub Category 2";
            PrintPaths("case1", ParsePaths(pathCase1));
            PrintPaths("case2", ParsePaths(pathCase2));
            Console.ReadLine();
        }
         private static void PrintPaths(string name, List<string> paths)
         {
             Console.WriteLine(name);
             Console.WriteLine();
             
             foreach (var item in paths)
             {
                 Console.WriteLine(item);
             }
             Console.WriteLine();
         }
        static string NormalizePath(string src)
        {
            // Remove "-> THIS DATA IS REDUNDANT" elements
            int idx = src.LastIndexOf('>');
            if (idx > 0 && src[idx - 1] == '-')
            {
                src = src.Substring(0, idx - 1);
            }
            var parts = src.SplitAndTrim('>');
            return string.Join(">", parts);
        }
         static List<string> ParsePaths(string text)
         {
             var items = text.SplitAndTrim('|');
             for (int i = 0; i < items.Count; ++i)
             {
                 items[i] = NormalizePath(items[i]);
             }
             items.Sort();
             var longestPaths = new SortedSet<string>();
             foreach (var s in items)
             {
                 int idx = s.LastIndexOf('>');
                 if (idx > 0)
                 {
                     var prefix = s.Substring(0, idx);
                     longestPaths.Remove(prefix);
                     longestPaths.Add(s);
                 }
                 else
                 {
                     longestPaths.Add(s);
                 }
             }
             return longestPaths.ToList();
         }
    }
