        private List<AdditionalPropertyType> SQLAddPropsStructured(DataTable dataTable)
        {
            AdditionalPropertyType lastNewType;             // to remember the previous new instance
            // for all rows...
            foreach (DataRow row in dataTable.Rows)
            {
                // the first type takes name and value from the first two fields
                AdditionalPropertyType newType = new AdditionalPropertyType();
                newType.Name = row[0].ToString();
                newType.Value = row[1].ToString();
                // remember this type: it is used as the AdditionalProperties for the NEXT type
                lastNewType = newType;
                // additional types start from field 2
                int field = 2;
                // iterate until we find a NULL  field.
                // If you want to check for the end of the fields rather than a NULL value, then instead use:
                //      while(field < dataTable.Columns.Count)
                while(!String.IsNullOrEmpty(row[field].ToString()))
                {
                    // create new type
                    var newSubType = new AdditionalPropertyType();
                    // get name
                    Name = row[field].ToString();
                    // new type takes the PREVIOUS type as its additional parameters
                    List<AdditionalPropertyType> propertyData = new List<AdditionalPropertyType>();
                    propertyData.Add(lastNewType);
                    newSubType.AdditionalProperties = propertyData;
                    // remember THIS type for the NEXT type
                    lastNewType = newSubType;
                    // process next field (if valid)
                    field++;
                }
                // put the last set of properties found into the current properties
                currentAdditionalProperties.Insert(0, lastNewType);
                return currentAdditionalProperties;
            }
        }
