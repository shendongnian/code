    static void Main(string[] args)
    {
            var min = 30;
            var max = 35;
            double num = 33;
            double step = 0.1;            
            while (true)
            {
                Console.Clear();
                
                num += num >= max || num <= min? (step = step * -1) : step;
                Console.Write(num);
                Thread.Sleep(200);
            }
    }
