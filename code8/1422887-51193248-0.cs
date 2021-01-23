    public string FiledName 
    { 
        get { return filedName; }
        set
        {
              filedName = !string.IsNullOrEmpty( value ) ? value.ToUpper() : value;           
        }
    }   
