    public int MilesPerGallon(int value)
    {
        return distance / gallons;
    }
    public double CostPerMile(double value)
    {
        return costOfGas * MilesPerGallon();
    }
    override    
    public string ToString()
    {
        return "Trip["
            + destination + ", "
            + distance + ", "
            + costOfGas + ", "
            + gallons + "]"
            + "\n Miles Per Gallon = " + MilesPerGallon()
            + ", Cost Per Mile = " + CostPerMile();
    }
