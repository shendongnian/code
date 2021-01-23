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
    
        private void ChangeField(bool value) { field = value; }
    
        public B()
        {
            Action<bool> Del = ChangeField;
    
            A instance = new A(Del);  // pass delegate with method to 2nd class
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
