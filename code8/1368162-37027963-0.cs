    private GridProperties grid;
    [Browsale(true)]
    public GridProperties Grid
    {
        get
        {
             return grid;
        }
        set
        {
            if(grid! = null)
                grid.PropertyChanged -= Redraw;
    
            grid = value;
            grid.PropertyChanged += Redraw;
        }
    }
