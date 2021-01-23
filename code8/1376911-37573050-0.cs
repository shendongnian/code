    foreach (var doc in batch)
      {
         if (custDictionary.ContainsKey(projectId))
            {
               string concatenatedCustomFields = custFieldsList.Aggregate(string.Empty,
                                (current, custField) =>
                                    current +
                                    (ds.Tables[0].Columns.Contains(custField)
                                        ? (ds.Tables[0].Rows[i][custField].GetType().Name == typeof(DBNull).Name
                                            ? string.Empty
                                            : ((string) ds.Tables[0].Rows[i][custField]).StripHtml())
                                        : string.Empty));
    
                            doc.Add("CustomFieldsConcatenated", concatenatedCustomFields);
            }
        i++;
     }
