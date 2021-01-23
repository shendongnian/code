    using (var db = new MyDataContext())
    {
        var res = db.MyModels.Include("SubModels").Where(x => x.RevId == revId).ToList();
        //"SubModels" would be the name of the navigation property... check your edmx schema for the actual name           
    }
