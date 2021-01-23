    public class Example : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("I was disposed of");
        }
        public int SomeMethod() => 1;
    }
