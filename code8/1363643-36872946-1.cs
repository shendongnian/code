     public static List<List<string>> logsIP1 = new List<List<string>>();
    
        public static void logsList()
        {
            logsIP1.Add(new List<string> { "a", "b" });
            logsIP1.Add(new List<string> { "c", "d", "e" });
        }
        
        public static void ReadNestedList()
        {        
            foreach (List<string> subList in logsIP1)
            {
               foreach (string item in subList)
               {
                   Console.WriteLine(item);
               }
            }
        }
