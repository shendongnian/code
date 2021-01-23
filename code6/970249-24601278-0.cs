    class Program
        {
            const string INPUT_FILE_NAME = "\\CIS210\\Ch8Prb3\\TextDat.Txt";
            static void Main(string[] args)
            {
                var s = System.IO.File.ReadAllText(INPUT_FILE_NAME).ToLower();
                var list = s.ToList();
                var group = list.GroupBy(i => i);
    
                foreach (var g in group)
                {
                    Console.WriteLine("{0} {1}", g.Key, g.Count());
                }
                Console.ReadLine();
            }
        }
