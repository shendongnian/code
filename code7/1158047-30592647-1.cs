    public readonly List<string> in_data_history = new List<string>();
    public string in_data
    {
         get {return in_data_history.Last();}
         set {in_data_history.Add(value);}
    }
