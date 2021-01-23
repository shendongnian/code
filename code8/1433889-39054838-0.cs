    static void Main(string[] args)
            {
                Random rn= new Random();
                while (true)
                {
                   
                    Console.WriteLine(DateTime.Now.Millisecond.ToString());
                    Console.WriteLine(rn.Next(10));
                }
        }
