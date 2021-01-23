    using System;
    
    public delegate void EventHandler();
    
    class Program
    {
        public static event EventHandler _show;
    
        static void Main()
        {
            var program = new Program();
            _show += new EventHandler(program.Dog);
            _show += new EventHandler(program.Cat);
            _show += new EventHandler(program.Mouse);
            _show += new EventHandler(program.Mouse);
        
            // Invoke the event.
            _show.Invoke();
        }
        
        void Cat()
        {
            Console.WriteLine("Cat");
        }
        
        void Dog()
        {
            Console.WriteLine("Dog");
        }
        
        void Mouse()
        {
            Console.WriteLine("Mouse");
        }
    }
