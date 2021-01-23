    public string IMG {
        get { return img; }
        set
        {
           if(value != img)
           {
               img = value;
            NotifyPropertyChanged();
           }
            
        }
