    class b  { 
        private c obj;
        public b()
        {
            
        }
        public void show(c o)
        {
            obj = o;
            obj.show();
        }
        }
        class c : b{ 
        public void show()
        {
        Console.WriteLine("working ");
        }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                c o=new c();
                b bo = new b();
                bo.show(o);
                o.show();
                Console.ReadKey();
    
            }
        }
