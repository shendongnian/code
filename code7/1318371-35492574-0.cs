    public delegate void SomeCallback();
    public interface ISomeInterface {
        SomeCallback callback { get; set; }
        void SomeMethod();
    }
    public class SomeClass : ISomeInterface
    {
        public SomeCallback callback { get; set; }
        public void SomeMethod()
        {
            callback.Invoke();
        }
    }
    public class MainClass
    {
        void Callback() { Console.WriteLine("Callback"); }
        public void Start()
        {
            ISomeInterface s = new SomeClass();
            s.callback = Callback;
            s.SomeMethod();
        }
    }
