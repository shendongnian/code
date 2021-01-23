    class Program
    {
        protected int ID;
    
        static void Main(string[] args)
        {
            var Obj = new Program();
            Obj.Inc();
            Console.WriteLine(Obj.ID);
            Console.ReadLine();
        }
    
        public int Inc()
        {
            ++ID;
            return ID;
        }
    
    }
