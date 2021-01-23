    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();
            try
            {
                worker.GetThing1();
                worker.GetThing2();
                worker.GetThing3();
            }
            catch (Exception errorMessage)
            {
                Console.WriteLine(errorMessage.Message);
            }
            Console.ReadKey();
        }
    }
    class Worker
    {
        public void GetThing1()
        {
            var success = true;
            if (!success)
            {
                throw new Exception("This is an error message!");
            }
            
        }
        public void GetThing2()
        {
            var success = false;
            if (!success)
            {
                throw new Exception("This is an error message!");
            }
        }
        public void GetThing3()
        {
            var success = true;
            if (!success)
            {
                throw new Exception("This is an error message!");
            }
        }
    }
