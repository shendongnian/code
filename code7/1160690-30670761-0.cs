    public String GetItemName(uint id)
    {
        IEnumerable<String> names = ...; // Query as before
        return names.FirstOrDefault() ?? "";
    }
