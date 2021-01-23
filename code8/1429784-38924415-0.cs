    string _XXContent 
    public string XXContent 
    {
        get
        {
            return _XXContent;
        }
        set
        {
            _XXContent = value;
            OnPropertyChanged("XXContent");
        }
    }
    
    
     private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
     {
         XXContent = e.UserState;
     }
