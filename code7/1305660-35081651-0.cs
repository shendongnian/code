    public bool this[int raw, int column]
    {
        get
        {
            // access internal jugged array 
            if (_data[raw] == null)
            {
                return false;
            }
            return _data[raw][column];   
        }
        set
        {
             if (_data[raw] == null)
             {
                 _data[raw] = new bool[Columns];
             }
    
            _data[raw][column] = value;
         
        } 
    }
    // Using a jugged array to store data
    private bool _data[][];
