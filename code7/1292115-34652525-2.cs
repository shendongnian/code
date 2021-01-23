    public static List<AdditionalPropertyType> SQLAddPropsStructured(DataTable dataTable, List<AdditionalPropertyType> currentadditionalproperties)
    {
        if(dataTable.Columns.Count < 2)
            throw new Exception("At least two columns are required");
        var currentadditionalproperties = new List<AdditionalPropertyType>();
        foreach (DataRow row in dataTable.Rows)
        {
            var tl = new AdditionalPropertyType
            {
                Name = row[0].ToString(),
                Value = row[1].ToString()
            };
            foreach(int index=2;index<dataTable.Columns.Count;index++)
            {
                if(String.IsNullOrEmpty(row[index].ToString()))
                    break;
                var previous = tl;
                var tl = new AdditionalPropertyType { Name = row[index].ToString() };
                tl.AdditionalProperties = new List<AdditionalPropertyType>();
                tl.AdditionalProperties.Add(previous);
            }
            currentadditionalproperties.Insert(0, tl);
        }
        return currentadditionalproperties;
    }
