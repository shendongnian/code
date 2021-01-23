    foreach (PropertyInfo property in typeof(QuickBook).GetProperties())
    {
        object value = property.GetValue(quickBook, null);
        if (value == null)
            line.Append(";");
        else
            line.AppendFormat("{0};", value);
    }
    
    if (line.Length > 0) //Removes the last ';'
        line.Remove(line.Length - 1, 1);
