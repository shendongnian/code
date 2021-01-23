    class Program
    {
        protected int ID;
    
        static void Main(string[] args)
        {
            var Obj = new Program();
            int value = Obj.Inc();
            Console.WriteLine(value);
            Console.ReadLine();
        }
    
        public int Inc()
        {
            ++ID;
            return ID;
        }
    
    }
