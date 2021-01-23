    static void Main(string[] args)
    {
        Hashtable ht = new Hashtable();
        string filterArg = "ZipCode=2130|~|ZipPlace=KNAPPER";
        string[] arrayColDef = { "ZipCode", "Space", "ZipPlace" };
        var properties = filterArg.Split(new string[] { "|~|" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var property in properties)
        {
            var nameValue = property.Split(arrayColDef, StringSplitOptions.RemoveEmptyEntries);
            var item = property.Split('=').First(); // get key
            var value = nameValue.First().TrimStart('='); // get value
            ht.Add(item, value);
        }
    }
