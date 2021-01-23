    public class Program
    {
        static void Main(string[] args)
        {
            Foo obj1 = new Foo("x1");
            // rewrite of
            // Action a = GetAction( obj1 );
            Foo obj = obj1;
            Action a = () => Console.WriteLine( obj.name );  
            obj1 = new Foo("x2");        
            a();                         
        }
    }
