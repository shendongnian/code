    var col1= db.columns.Where(w => w.category.Equals("Cars"));
    foreach (var item in col1)
    {
        item.SPECIFIC_PROPERTY = "VALUE";
    }
    
    try
    {
        db.SubmitChanges();
    }
    catch (Exception ex)
    {
       //Handle ex
    }
