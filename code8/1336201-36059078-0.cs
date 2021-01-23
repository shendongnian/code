    class Program
     {
         static void Main(string[] args)
         {
             new Bar();
         }
     }
    
    
    class Foo
    {
        public Foo()
        {
            MessageBox.Show("Foo");
        }
    }
    
    class Bar : Foo
    {
        public Bar()
        {
            MessageBox.Show("Bar");
        }
    }
