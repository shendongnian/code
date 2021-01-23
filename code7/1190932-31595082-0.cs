    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                Func<string, string[], Dictionary<string, int>> searchForCounts = null;
                searchForCounts = (filePathAndName, searchTerms) =>
                {
                    Dictionary<string, int> results = new Dictionary<string, int>();
                    if (string.IsNullOrEmpty(filePathAndName) || !File.Exists(filePathAndName))
                        return results;
                    using (TextReader tr = File.OpenText(filePathAndName))
                    {
                        string line = null;
                        while ((line = tr.ReadLine()) != null)
                        {
                            for (int i = 0; i < searchTerms.Length; ++i)
                            {
                                var searchTerm = searchTerms[i].ToLower();
                                var index = 0;
                                while (index > -1)
                                {
                                    index = line.IndexOf(searchTerm, index, StringComparison.OrdinalIgnoreCase);
                                    if (index > -1)
                                    {
                                        if (results.ContainsKey(searchTerm))
                                            results[searchTerm] += 1;
                                        else
                                            results[searchTerm] = 1;
                                        index += searchTerm.Length - 1;
                                    }
                                }
                            }
                        }
                    }
                    return results;
                };
                var counts = searchForCounts("D:\\Projects\\ConsoleApplication5\\ConsoleApplication5\\TestLog.txt", new string[] { "one", "two" });
                Console.WriteLine("----Counts----");
                foreach (var keyPair in counts)
                {
                    Console.WriteLine("Term: " + keyPair.Key.PadRight(10, ' ') + " Count: " + keyPair.Value.ToString());
                }
                Console.ReadKey(true);
            }
        }
    }
    Input:
    OnE, TwO
    Output:
    ----Counts----
    Term: one        Count: 7
    Term: two        Count: 15
    
