    namespace TestApp
    {
    class Program
    {
        static void Main(string[] args)
        {
            while (!MySingleton.Instance.IsReady)
                Thread.Sleep(100);
            Console.WriteLine("Done");
            Console.Read();
        }
    }
    public class MySingleton
    {
        static MySingleton()
        {
        }
        private static readonly MySingleton instance = new MySingleton();
        private static bool threadFinished = false;
        public bool IsReady
        {
            get { return threadFinished; }       
        }
        private MySingleton()
        {
            Thread t = new Thread(new ThreadStart(MyAction));
            
            t.Start();
        }
        public static MySingleton Instance
        {
            get { return instance; }
        }
        static void MyAction()
        {
            threadFinished = true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            while (!MySingleton.Instance.IsReady)
                Thread.Sleep(100);
            Console.WriteLine("Done");
            Console.Read();
        }
    }
  
