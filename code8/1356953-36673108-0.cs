    private double? ValidatePrice(string priceInput)
    {
        double? priceOutput = default(double?);     
        Double.TryParse(priceInput, out priceOutput)
        return priceOutput;
    }
