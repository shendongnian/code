       // static: you don't want "this" in the method
       // String: you want a String, not double, right?
       public static String volumeCalculation(Order order) { 
         // Since method is public one, validate input
         if (null == order)
           throw new ArgumentNullException("order");
      
         // I suggest using Linq here
         return Order.ShipOrders
           .Select(line => line.Split('X'))
           .Select(items => items
             .Select(item => double.Parse(item) / 100.0)
             .Aggregate((x, s) => x * s))
           .Sum()
           .ToString("00.0000", CultureInfo.InvariantCulture) // <- formatting
           .Replace(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator, "");
       }
