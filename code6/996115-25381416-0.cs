    public int Column1
    {
        get { return column1; }
        set 
        {
            column1 = value; 
            NotifyPropertyChanged("Column1"); 
            NotifyPropertyChanged("Column3"); 
        }
    }
    public int Column2
    {
        get { return column2; }
        set 
        { 
            column2 = value; 
            NotifyPropertyChanged("Column2"); 
            NotifyPropertyChanged("Column3"); 
        }
    }
    public int Column3
    {
        get { return Column2 - Column1; }
    }
