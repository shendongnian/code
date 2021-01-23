    Dictionary<String, Decimal> grandFunkers = GetGrandFunkers();
    grandFunkers.DataSource = new BindingSource(dict, null);
    grandFunkers.DisplayMember = "Key";
    grandFunkers.ValueMember = "Value";
    public static Dictionary<string, Decimal> GetGrandFunkers()
    { 
        Dictionary<string, string> grandFunk = new Dictionary<string, string>
        {
            {"Mark Farner", 99.42},
            {"Don Brewer", 97.76},
            {"Mel Schacher", 88.39},
            {"Craig Frost", 71.87}
        };
        return grandFunk;
    }
