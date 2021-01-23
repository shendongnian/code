    if (reader.Name == "Result")
       {
           //DataRow workRow = dt.NewRow();
       }
    if (columns.Contains(reader.Name))
       {
           DataRow workRow = dt.NewRow();
           //ERROR IS HERE out of context
           workRow[reader.Name] = reader.Value;
       }
