     static void Main(string[] args)
     {
            char[] chrs = { 'A', 'B', 'C' };
            char[] chrs2 = { 'X', 'Y', 'Z' };
            
            Console.WriteLine("For ABC and XYZ: ");
            foreach (var p in Pairs(chrs,chrs2))
                Console.WriteLine(p);
            Console.WriteLine();
            Console.WriteLine("For D and W: ");
            chrs = new char[] { 'D' };
            chrs2 = new char[] { 'W' };
            foreach (var p in Pairs(chrs, chrs2))
                Console.WriteLine(p);
    }
