    Class Base
    {
        static List<string> a;
        static List<string> b;   
        public Base()
        {
            if(this.a == null)
            {
                 a = database.GetListitemsForA();
            }
            if(this.b == null)
            {
                 b = database.GetListitemsForB();
            }
            
        }
    }
