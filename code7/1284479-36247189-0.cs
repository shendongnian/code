    using System;
    class Base
    {
        public event EventHandler OperationsChanged {get; set;}
    }
    class Derived : Base
    {
       public void OnSpecificOperationChanged()
       {
            OperationsChanged(this, EventArgs.Empty);
       }
    }
    
    class Test
    {
        static void  Main()
        {
            Derived d = new Derived();
           d.OperationsChanged += OnOperationsChanged;
           //invoke
           d.OnSpecificOperationChanged();
        } 
        static void OnOperationsChanged(object sender, EventArgs e)
        {
            Console.WriteLine("called");
        }
    }
