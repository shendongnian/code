        public class Program
        {
            public static IEnumerable<object> Accept()
            {
                var userList = new List<object>();
                var index = 0;
                while (true)
                {
                    var msg = "setup";
                    if (msg == "setup")
                    {
                        var returnUser = new
                        {
                            Name = "in method " + index
    
                        };
                        Thread.Sleep(300);
                        yield return returnUser;
                    }
                    index++;
                }
            }
    
            private static void Main(string[] args)
            {
                foreach (var acc in Accept())
                {
                    Console.WriteLine(acc.ToString());
                }
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }
