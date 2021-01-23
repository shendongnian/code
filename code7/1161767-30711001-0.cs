    private string CheckTextLength(string value, string text)
    {
        if (value.Length < 100)
        {
            return value;
        }
        else
        {
            MyDispatcher.BeginInvoke(new Action(() =>
                OnPropertyChanged("Text")), 
                DispatcherPriority.Loaded);
            return text; 
        }
    }
