    public double UptoTwoDecimalPoints(double num)
    {
        var totalCost = Convert.ToDouble(String.Format("{0:0.00}", num));
        return totalCost;
    }
