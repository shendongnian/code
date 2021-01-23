    public string GetInsertSql()
    {
        string query;
        string insert = "INSERT INTO MyTable (";
        string values = "VALUES (";
        PropertyInfo[] properties = typeof(MyClass).GetProperties();
        foreach (PropertyInfo property in properties)
        {
            if(! String.IsNullOrWhiteSpace(property.GetValue(this).ToString()))
            {
                insert += "[" + property.Name + "], ";            
                values += property.GetValue(this) + ", ";
            }
        }
        insert = insert.TrimEnd(',', ' ');
        values = values.TrimEnd(',', ' ');
        insert += ") ";
        values += ")";
        query = insert + " " + values;
        return query;
    }
