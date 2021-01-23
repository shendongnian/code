    class Program
    {
        public static int WindowCounter = 0;
        private static Window _firstWindow;
        [STAThread]
        public static void Main()
        {
            ShowBeforeApplicationCreation();
        }
        public static void ShowBeforeApplicationCreation()
        {
            ShowWindow();
            ShowWindow();
            ShowWindow();
            var app = new Application();
            app.Run(_firstWindow);
        }
        public static void ShowWindow()
        {
            var window = new Window { Title = string.Format("Title{0}", WindowCounter++) };
            window.Show();
            _firstWindow = _firstWindow ?? window;
        }
    }
