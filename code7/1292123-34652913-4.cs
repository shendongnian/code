    public static List<AdditionalPropertyType> SQLAddPropsStructured(DataTable dataTable, List<AdditionalPropertyType> currentadditionalproperties)
    {
        foreach (DataRow row in dataTable.Rows)
        {
            var tl = new AdditionalPropertyType
            {
                Name = row[0].ToString(),
                Value = row[1].ToString()
            };
            if (String.IsNullOrEmpty(row[2].ToString())){
                 currentadditionalproperties.Insert(0, tl);
                 continue;
            }
            var ltwo = new AdditionalPropertyType
            {
                Name = row[2].ToString()
            };
            var ltwolist = new List<AdditionalPropertyType>();
            ltwolist.Add(tl);
            ltwo.AdditionalProperties = ltwolist;
            if (String.IsNullOrEmpty(row[3].ToString())) {
                currentadditionalproperties.Insert(0, ltwo);
                continue;
            }
            var lthree = new AdditionalPropertyType
            {
                Name = row[3].ToString()
            };
            var lthreelist = new List<AdditionalPropertyType>();
            lthreelist.Add(ltwo);
            lthree.AdditionalProperties = lthreelist;
            currentadditionalproperties.Insert(0, lthree);                                            
        }
        return currentadditionalproperties;
    }
