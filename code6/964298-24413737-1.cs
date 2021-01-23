    internal class Program
    {
        private static DisposableScope _proxy = null;
        private static void Main(string[] args)
        {
            using (_proxy)
            {
                _proxy = new DisposableScope();
            }
        }
    }
    public class DisposableScope : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }
    }
