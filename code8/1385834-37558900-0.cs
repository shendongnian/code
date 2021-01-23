    public String[] data = new String[25] { // declare strings here }
    // indexer
    public String this [int num]
    {
        get
        {
            return data[num];
        }
        set
        {
            data[num] = value;
        }
    };
