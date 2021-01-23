    public class SingleWindowTypeHelper
    {
        public SingleWindowTypeHelper()
        {
            _windows = new List<Window>();
        }
        private readonly List<Window> _windows;
        public T GetExistingWindow<T>()
        {
            return _windows.OfType<T>().FirstOrDefault();
        }
        public bool ShowExistingWindow<T>() where T : Window
        {
            T window = GetExistingWindow<T>();
            if (window == null) return false;
            if (window.WindowState == WindowState.Minimized)
                window.WindowState = WindowState.Normal;
            window.Activate();
            return true;
        }
        public void AddNewWindow(Window window)
        {
            _windows.Add(window);
            window.Closed += WindowOnClosed;
            window.Show();
            window.Activate();
        }
        private void WindowOnClosed(object sender, EventArgs eventArgs)
        {
            Window window = sender as Window;
            if (window == null) return;
            window.Closed -= WindowOnClosed;
            _windows.Remove(window);
        }
    }
