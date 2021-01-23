    public LoggerViewModel(Logger loggerModel /* Dependency injection*/)
    {
        _LoggerModel = loggerModel;
        _LoggerModel.PropertyChanged += this.LoggerModel_PropertyChanged;
    }
    
    private void LoggerModel_PropertyChanged(object sender, PropertyChangedEventArgs args)
    {
        if (args.PropertyName == "Entries")
        {
            StringBuilder text = new StringBuilder();  // Use StringBuilder for performance
            List<LogEntry> entries = new List<LogEntry>(_LoggerModel.Entries);
            foreach (LogEntry entry in entries)
            {
                text.AppendLine(entry.ToString());
            }
            this.LoggerText = text.ToString();            
        }
    }
    private string _loggerText;
    public string LoggerText
    {
        set
        {
           _loggerText = value;
           RaisePropertyChanged("LoggerText");
        }
        get
        {
            return _loggerText;
        }
    }
