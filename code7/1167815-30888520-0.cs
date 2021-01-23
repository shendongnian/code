    public void PopulateDropDownList(DropDownList ddl, IEnumerable list, Type type)
    {
        object obj = Activator.CreateInstance(type);
        foreach (var item in list)
            ddl.Items.Add(new ListItem(((dynamic)item).Name, ((dynamic)item).ID.ToString()));
    }
