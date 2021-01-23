     class Program
     {
        static void Main(string[] args)
        {
            List<string> lstAgents = new List<string>() { "Agent1", "Agent2","Agent3" };
            List<string> lstAccounts = new List<string>() { "1001", "1002" ,"1003", "1004", "1005" };
            var op = lstAccounts.Split(lstAgents.Count);
            int i = 0;
            foreach (var accounts in op)
            {
                //Get agent
                Console.WriteLine("Account(s) for Agent: ", lstAgents[i]);
                foreach (var acc in accounts)
                {
                    Console.WriteLine(acc);
                }
                Console.WriteLine(Environment.NewLine);
                i++;
            }
            
            Console.ReadKey();
        }
    
    
     }
      static class LinqExtensions
      {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
        {
            int i = 0;
            var splits = from item in list
                         group item by i++ % parts into part
                         select part.AsEnumerable();
            return splits;
        }
    }
