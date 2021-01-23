    void Main()
    {
      string country = ""; //"Brazil"
      string city = ""; //"Sao Paulo"
      DateTime? orderDate = null;//new DateTime(1996,8,28);
    
      var data = Orders.AsQueryable();
    
      if (!string.IsNullOrEmpty(country))
      {
        data = data.Where(c => c.ShipCountry.StartsWith(country));
      }
      if (!string.IsNullOrEmpty(city))
      {
        data = data.Where(c => c.ShipCity.StartsWith(city));
      }
      if (orderDate != null)
      {
        data = data.Where(c => c.OrderDate == orderDate);
      }
    }
