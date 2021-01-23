    public double volumeCalculation(Order order)
    {
        double totalVolume = 0;
    
        foreach (var item in order.ShipOrders)
        {
            var dims = $"{item.Dimensions.Substring(0,2)}.{item.Dimensions.Substring(2)}";
           var vol = double.Parse(dims);
           totalVolume += vol;
        }
        return totalVolume;
    }
