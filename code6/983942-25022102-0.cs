    using (DataClassesDataContext db = new DataClassesDataContext())
    {
        List<view_subject> results = db.ExecuteQuery<view_subject>(query).ToList();
    
        if (dataBind)
        {
            GridViewSearchResults.DataSource = results;
            GridViewSearchResults.DataBind();
        }
    
        return results.Count();
    }
