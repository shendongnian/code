    private int id;
    public int ID
    {
        get
        {
            return this.id;
        }
    
        set
        {
            if (value != this.id)
            {
                this.id= value;
                NotifyPropertyChanged("ID");
            }
        }
    }
