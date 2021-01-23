    public class Program
    {
        public static void Main(string[] args)
        {
            var container = GetIoC();
            container.Bind<App>().ToSelf();
            //resolve root
            var app = container.Get<App>();
            app.Start(); 
        }
    }
