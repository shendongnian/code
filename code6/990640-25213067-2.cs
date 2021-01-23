    public string Get([FromUri]List<string> Names)
    {
        string output = "Requested name";
        foreach (var item in Names)
        {
            output += ":" + item;
        }
        return output;
    }
