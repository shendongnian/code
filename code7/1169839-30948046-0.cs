    string filename;
    public string Filename
    {
       get {return filename;}
       set {
          if (filename != value)
          {
             filename = value;
             OnNotifyPropertyChanged("Filename");
             WatchFile();
             UpdateFileText();
          }
    }
    
    string fileText;
    public string FileText
    {
       get {return fileText;}
       set {
          fileText = value;
          OnNotifyPropertyChanged("FileText");
       }
    }
    
    private void WatchFile()
    {
       // Create FileSystemWatcher on filename
       // Call UpdateFileText when file is changed
    }
    
    private void UpdateFileText()
    {
       // Code from your converter
       // Set FileText
    }
