    List<Bus> buses = new List<Bus>();
    Bus busx = new Bus()
    {
       Date = new DateTime(year, month, day),
       ServiceNumber = "X"
    }
    
    busx.ServiceNumbers.Add("servicenumberx");
    buses.add(busx);
