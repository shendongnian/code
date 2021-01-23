    public static List<AdditionalPropertyType> SQLAddPropsStructured(DataTable dataTable, List<AdditionalPropertyType> currentadditionalproperties)
    {
        // check if there are atleast 2 columns defined
        if(dataTable.Columns.Count < 2)
            throw new Exception("At least two columns are required");
        // The result
        var currentadditionalproperties = new List<AdditionalPropertyType>();
        // iterate the rows
        foreach (DataRow row in dataTable.Rows)
        {
            // create the base property
            var tl = new AdditionalPropertyType
            {
                Name = row[0].ToString(),
                Value = row[1].ToString()
            };
            // check the rest of the columns for additional names
            foreach(int index=2;index<dataTable.Columns.Count;index++)
            {
                var columnValue = row[index].ToString();
                // if the column is empty, discontinue the iteration
                if(String.IsNullOrEmpty(columnValue))
                    break;
                // create a backup reference.
                var previous = tl;
                // create a new AdditionalPropertyType
                var tl = new AdditionalPropertyType { Name = columnValue };
                // Create the list
                tl.AdditionalProperties = new List<AdditionalPropertyType>();
                // add the previous (backup reference)
                tl.AdditionalProperties.Add(previous);
            }
            // insert the 'chain' of additional properties on the list at possition 0
            currentadditionalproperties.Insert(0, tl);
        }
        // return the list
        return currentadditionalproperties;
    }
