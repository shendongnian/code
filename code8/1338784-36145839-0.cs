    public Dictionary<string, double> Items
    {
        get
        {
            var d = new Dictionary<string, double>();
            foreach (var item in Enumerable.Range(1, 10))
            {
                d.Add($"Key{item}", item);
            }
            return d;
        }
    }
