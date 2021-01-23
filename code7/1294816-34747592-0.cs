    class Program
    {
        static void Main()
        {
            var p = new Processor();
            p.ExceptionThrown += p_ExceptionThrown;
            for (var i = 0; i < 10; i++)
                p.ProcessAsync(i);
            Console.ReadKey();
        }
    
        static void p_ExceptionThrown(object sender, Exception e)
        {
            Console.WriteLine("Exception caught in Main : " + e);
        }
    }
    
    class Processor
    {
        public async Task ProcessAsync(int iteration)
        {
            try
            {
                await Task.Run(() => Process(iteration));
            }
            catch (Exception e)
            {
                OnException(e);
            }
        }
    
        public void Process(int iteration)
        {
            Thread.Sleep(500);
            if(iteration == 5)
                throw new Exception("AUUCH");
        }
    
        public event EventHandler<Exception> ExceptionThrown;
    
        void OnException(Exception e)
        {
            var handler = ExceptionThrown;
            if (handler != null)
                handler(this, e);
        }
    }
