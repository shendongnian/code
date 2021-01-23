    public static class Controli
    {
        public Window Window
        {
            get
            {
                var application = Application.Current;
                if(application == null)
                    return null;
                try
                {
                    return application.MainWindow;
                }
                catch(InvalidOperationException)
                {
                    return application.Dispatcher.Invoke(() => application.MainWindow);
                }
            }
        }
    }
