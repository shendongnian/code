    static void Main(string[] args)
        {
            var mySlow = new SlowClass();
            var mySlow2 = new SlowClass();
    
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
                mySlow.GetData();
                mySlow2.GetData();
            }
              
    
            Console.Read();
        }
