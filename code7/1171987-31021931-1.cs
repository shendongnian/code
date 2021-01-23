    class Class5
    {
        static void Main()
        {
            string file = @"YYY qqq                ccc              YYY                       ddd                      XXX  zzz YYY         zzz      ddd    YYY";            
    
            Match matchX = new Regex("XXX").Match(file);
    
            MatchCollection matchesY = new Regex("YYY").Matches(file);
            int minYIndex = -1;
    
            foreach (Match item in matchesY)
            {
                if (matchX.Index - item.Index > matchX.Index - minIndex || matchX.Index - item.Index < 0) continue;
                minYIndex = item.Index;
            }
    
            Console.WriteLine("Index of closest Y: {0}, Value: {1}", minYIndex, file.Substring(minIndex, 3));
    
            Console.ReadKey();
        }
    }
