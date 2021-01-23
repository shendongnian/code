    public static List<AdditionalPropertyType> SQLAddPropsStructured(DataTable dataTable, List<AdditionalPropertyType> currentadditionalproperties)
    {
        foreach (DataRow row in dataTable.Rows)
        {
            var tlprev = new AdditionalPropertyType
            {
                Name = row[0].ToString(),
                Value = row[1].ToString()
            };
            bool isTlUpdated = true;
            for (int i = 2; i <= 3; ++i) { //change this according to your need
                if (String.IsNullOrEmpty(row[i].ToString()) && isTlUpdated){
                    currentadditionalproperties.Insert(0, tlprev);
                    isTlUpdated = false;
                    continue;
                }
                var lnext = new AdditionalPropertyType
                {
                    Name = row[i].ToString()
                };
                var lnextlist = new List<AdditionalPropertyType>();
                lnextlist.Add(tlprev);
                lnext.AdditionalProperties = lnextlist;
                tlprev = lnext; //need to record this for the next loop or end of the case
                isTlUpdated = true;
            }
            if (isTlUpdated) //correction by Jeroen
                currentadditionalproperties.Insert(0, tlprev);                                            
        }
        return currentadditionalproperties;
    }
