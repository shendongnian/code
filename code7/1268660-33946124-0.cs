    static void Main(string[] args)
        {
           int prevTick = 0;
            while (true)
            {
                int curTick = DateTime.Now.Second;
                if (curTick != prevTick)
                {
                    //Perform action in here
                    Console.WriteLine("tick");
                    prevTick = curTick;
                }
                Thread.Sleep(100);
            }
        }
