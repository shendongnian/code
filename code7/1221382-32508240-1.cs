    public int MilesPerGallon { get { return distance / gallons; } }
    public double CostPerMile { get { return costOfGas * MilesPerGallon; } }
    override    
    public string ToString()
    {
        return "Trip["
            + destination + ", "
            + distance + ", "
            + costOfGas + ", "
            + gallons + "]"
            + "\n Miles Per Gallon = " + MilesPerGallon
            + ", Cost Per Mile = " + CostPerMile;
    }
