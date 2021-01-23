    public int MPG
    {
        get { return distance / gallons; }
    }
    public double CPM
    {
        get { return costOfGas * MPG; }
    }
