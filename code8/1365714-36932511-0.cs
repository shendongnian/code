    public List<Person> GetPersons()
    {
         var table = context.ExecutDataTable();
         return GetModelList<Person>(table);
    }
    public List<T> GetModelList<T>(DataTable table) where T : ModelBase, new()
    {        
        var list = new List<T>();
        foreach(DataRowView row in table.DefaultView)
        {
            var item = new T();
            t.Load(row);
            list.Add(item);
        }
        return list;
    }
