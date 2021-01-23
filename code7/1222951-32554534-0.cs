    namespace inst
    {
        public class Program
        {
            private string Path
            {
                get {return AppDomain.CurrentDomain.BaseDirectory.ToString();}
            }
            [STAThread]
            static void Main()
            {
            }
    }
