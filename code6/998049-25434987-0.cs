    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    
    namespace OrderFinder
    {
        class Program
        {
            static void Main(string[] args)
            {
                string SearchDir = @"Y:\imported";
                string SearchExp = "*.xml";
                string MustHave = "{xmlfile}.out";
                string name, find;
                try
                {
                    foreach (var file in Directory.EnumerateFiles(SearchDir, SearchExp, SearchOption.TopDirectoryOnly))
                    {
                        name = file.Substring(SearchDir.Length + 1);
                        find = SearchDir + "\\" + MustHave.Replace("{xmlfile}", Path.GetFileNameWithoutExtension(file));
    
                        if (!File.Exists(find))
                        {
                            Console.WriteLine("[WARN] Mismatched: " + Path.GetFileNameWithoutExtension(file));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[ERR] Exception: " + ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
