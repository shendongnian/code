    var lines = File.ReadAllLines("PizzaFile.csv")
    List<PizzaOrder> orders = new List<PizzaOrder>();
    foreach (var line in lines)
    {
        var fields = line.Split(',');
        PizzaOrder order = new PizzaOrder()
        {
            Id = Convert.ToInt32(fields[0].Trim());
            Type = fields[1].Trim();
            // etc.
        }
    }
    var result = orders.ToArray();
