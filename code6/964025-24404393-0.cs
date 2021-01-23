    if(string.IsNullOrEmpty(lstTypeSearch.SelectedItem))
    {
        // nothing to check?
    }
    else
    {
        CheckValidColumn(lstTypeSearch.SelectedItem); // throws if white-list fails
        sql.Append(" AND TT.[_TYPE] = [") // should probably add table alias
           .Append(lstTypeSearch.SelectedItem)
           .Append("]");
    }    
