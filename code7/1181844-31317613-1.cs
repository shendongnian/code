    class A
    {
        public A(Action<bool> del)
        {
            del(true); // invoke delegate method and pass new value
        }
    }
    
    class B
    {
        private bool field;       
    
        public B()
        {
            // pass a lambda expression with delegate to 2nd class
            A instance = new A(newValue => field = newValue);  
        }        
    
        public void ShowField()
        {
            Console.WriteLine(field);
        }
    }
    
    class Program
    {            
        static void Main()
        {
            B i = new B();
            i.ShowField();
            Console.ReadKey();
        }
    }
