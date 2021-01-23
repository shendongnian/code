    public string AppStatus
        {
          get { return (string)GetValue(AppStatusProperty); }
          set { SetValue(AppStatusProperty, value); }
        }
        public static readonly DependencyProperty AppStatusProperty =
            DependencyProperty.Register("AppStatus", typeof(string), typeof(MainWindow), new PropertyMetadata(null));
    
    public void StatusBarUpdate(string strMainMessage)
        {
          Dispatcher.BeginInvoke((Action)(() => { AppStatus = strMainMessage; }));
        }
