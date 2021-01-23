    using System;
    using LibGit2Sharp;
    
    class Program
    {
        public static void Main(string[] args)
        {
            using (var repo = new Repository(@"C:\Repo"))
            {
                foreach (IndexEntry e in repo.Index)
                {
                    Console.WriteLine("{0} {1}", e.Path, e.StageLevel);
                }
            }
    
            Console.ReadLine();
        }
    }
