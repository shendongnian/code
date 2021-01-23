    public class MainWindow
    {
        public UserControl UserControlInstance = new UserControl();
        public string textPropertyMainWindow;
        public MainWindow()
        {
           UserControlInstance.TextBoxText.PropertyChanged += PropertyChangedHandler;
        }
        
        private void PropertyChangedHandler(object obj)
        {
           textPropertyMainWindow = UserControlInstance.TextBoxText;
        }
    }
