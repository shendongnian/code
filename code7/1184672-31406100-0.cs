    static void Main(string[] args)
    {
        Hashtable ht = new Hashtable();
        string filterArg = "ZipCode=2130|~|ZipPlace=KNAPPER";
        string[] arrayColDef = { "ZipCode", "Space", "ZipPlace" };
        var properties = filterArg.Split(new string[] { "|~|" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var property in properties)
        {
            var nameValue = property.Split(arrayColDef, StringSplitOptions.None);
            var item = nameValue[0];
            var value = nameValue[1].TrimStart('=');
            ht.Add(item, value);
        }
    }
