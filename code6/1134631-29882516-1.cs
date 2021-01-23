    public string Title
    {
        get { return title; }
        set 
        { 
            if (value == title)  
              return;
            if (string.IsNullOrEmpty(value))
              throw new ArgumentException("Title");
            title = value;  
        }
    }
