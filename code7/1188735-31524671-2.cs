    public class DisposableParent : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("The parent was disposed.");
        }
    }
    public class DisposableChild : DisposableParent, IDisposable
    {
        public new void Dispose()
        {
            base.Dispose();
            Console.WriteLine("The child was disposed.");
        }
    }
    public class Program
    {
        public static void Main()
        {
             using (DisposableChild c = new DisposableChild()) { }
             Console.ReadKey(true);
        }
    }
