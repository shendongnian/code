    ActionsEntry entry = (ActionsEntry)ser.Deserialize(fs);
    foreach (var action in entry.Actions)
    {
        string interval = action.Interval.Replace(',', '.');
        decimal intvrl = Decimal.Parse(interval);
        Console.WriteLine(intvrl);
    }
