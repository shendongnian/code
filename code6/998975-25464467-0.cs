    public RadGridView Grid
    {
        get { return grid; }
        set
        {
            if (grid != value)
            {
                grid = value;
                // Add any special processing that summary needs to do to pull data from the SalesPoint Grid property.
            }
        }
    }
