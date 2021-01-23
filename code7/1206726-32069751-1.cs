    static void Main(string[] args)
    {
            var min = 31;
            var max = 33;
            double num = 32;
            double step = 0.10;            
            while (true)
            {
                Console.Clear();
                
                num += num >= max || num <= min? (step = step * -1) : step;
                Console.Write(num);
                Thread.Sleep(200);
            }
    }
