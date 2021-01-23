    if(string.IsNullOrEmpty(lstTypeSearch.SelectedItem))
    {
        // no restriction?
    }
    else
    {
        sql.Append(" AND TT.[_TYPE] = @type");
        cmd.Parameters.AddWithValue("type", lstTypeSearch.SelectedItem);
    }
    // ...
    cmd.CommandText = sql.ToString();
