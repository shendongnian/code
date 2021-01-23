    string bigText 
    string BigText  
    {
        get { return bigText; }
        set 
        {
            bigText = value;
            Normalize_button.IsEnabled = true;
            NotifyPropertyChanged("BigText");
        }
    }
    
    FileBuff = sr.ReadToEndAsync();
    BigText = await FileBuff;
