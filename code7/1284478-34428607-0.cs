    using System;
    class Base
    {
        public event EventHandler operationsChanged;
        public void OnOperationsChanged(EventArgs e)
        {
            operationsChanged(this,e);
        }
    }
    class Derived : Base
    {
        public void OnSpecificOperationChanged()
        {
            OnOperationsChanged(EventArgs.Empty);
        }
    }
    class Test
    {
        static void  Main()
        {
            Derived d = new Derived();
            d.operationsChanged += OnOperationsChanged;
        
            //invoke
            d.OnSpecificOperationChanged();
        
        }
        static void OnOperationsChanged(object sender, EventArgs e)
        {
            Console.WriteLine("called");
        }
    }
