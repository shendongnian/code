    public class Program
    {
        public static void Main()
        {
            DisposableChild c = new DisposableChild();
            DisposeOfIt(c);
    
            Console.ReadKey(true);
        }
    
        public static void DisposeOfIt(DisposableParent p)
        {
            p.Dispose();
        }
    }
