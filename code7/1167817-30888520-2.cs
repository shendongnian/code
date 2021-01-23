    public void PopulateDropDownList<T>(DropDownList ddl, IEnumerable list, Func<T, string> key, Func<T, string> value)
    {
        foreach (T item in list)
            ddl.Items.Add(new ListItem(key(item), value(item));
    }
    PopulateDropDownList<MyClass>(ddl, GetList(), x => x.Name, x => x.ID.ToString());
