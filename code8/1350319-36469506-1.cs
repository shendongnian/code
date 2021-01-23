    public DataTable GetMCCHABAKflokka(string tableName, string sort, string filter)
    {
        var result = GetMCCHABAKflokka(tableName);
        result.DefaultView.Sort = sort;
        result.DefaultView.Filter = filter;
        return result;
    }    
    
    // use like this
    foreach (DataRowView row in result.DefaultView)
   
    
