    class A
    {
        public A(Action<bool> del)
        {
            del(true);
        }
    }
    class B
    {
        private bool field;        
        private void ChangeField(bool value) { field = value; }
        public B()
        {
            Action<bool> Del = ChangeField;
            A instance = new A(Del);
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
