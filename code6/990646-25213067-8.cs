    public string Get([ModelBinder(typeof(MyModelBinder))] List<string> name)
    {
        string output = "Requested name";
        foreach (var item in name)
        {
            output += ":" + item;
        }
        return output;
    }
