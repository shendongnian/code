    class BaseShape
    {
        public virtual void Display()
        {
            Console.WriteLine("Displaying Base Class!");
    
        }
    }
    class Circle : BaseShape
    {
        public override void Display()
        {
            Console.WriteLine("Displaying Circle Class!");            
        }
    }
    class Rectangle : BaseShape
    {
        public override void Display()
        {
            Console.WriteLine("Displaying Rectangle Class!");            
        }
    }
