    private static void Main()
    {
         var list = new[]
         {
             "ARCH 6359 Spring 2015", "BIOL 3324 Fall 2013", "ENGI 2304 SP15", "GCSW FA 13", "GENB 4350 Summer 2011",
             "GROUP Writing Consultations 2011Fall", "YES Prep Fa12"
         };
         var toRemove = new[] {"SP", "SPRING", "FA", "Fall", "Summer"};
         foreach (var str in list)
         {
            var items = Regex.Split(str, @"(?<=\D)(?=\d)|(?<=\d)(?=\D)|(\s+)")
                    .Select(i => i.Trim())
                    .Where(i => i != "" && !toRemove.Contains(i, StringComparer.OrdinalIgnoreCase));
                                    
            Console.WriteLine(String.Join(" ",items));
        }
        Console.Read();
    }
