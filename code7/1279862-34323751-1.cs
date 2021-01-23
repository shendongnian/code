    class Program
    {
        static void Main(string[] args) {
            ICompositeWindow window = null;
            var container = new CompositeContainer();
            container.Configure();
            window = container.Resolve<ICompositeWindow>();
            window.Show();
            window.BeforeClose();
        }
    }
