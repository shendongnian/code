    class OverrideAndNew
    {
        public static void Main()
        {
            Derive obj = new Derive1();
            obj.Show();
    
            Console.ReadLine();
        }
    }
    
    class Base
    {
        public virtual void Show()
        {
            Console.WriteLine("Base - Show");
        }
    }
    
    class Derive : Base
    {
        public override void Show()
        {
            Console.WriteLine("Derive - Show");
        }
    }
    
    class Derive1 : Derive
    {
        public override void Show()
        {
            Console.WriteLine("Derive1 - Show");
        }
    }
