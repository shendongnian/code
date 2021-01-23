    class Class5
    {
        static void Main()
        {
            string file = @"YYY qqq                ccc              YYY                       ddd                      XXX  zzz YYY         zzz      ddd    YYY";            
            Match matchX = new Regex("XXX").Match(file);            
            MatchCollection collection = new Regex("YYY").Matches(file);
            Match[] matchesY = new Match[collection.Count];
            collection.CopyTo(matchesY, 0);
            int ClosestY = matchX.Index - matchesY.Where(m => matchX.Index > m.Index).Min(m => matchX.Index - m.Index);
            Console.WriteLine("Index of closest Y: {0}, Value: {1}", ClosestY, file.Substring(ClosestY, 3));
            Console.ReadKey();
        }
    }
