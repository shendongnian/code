    using (var db = new MyDataContext())
    {
        var query = db.MyModels.As Queryable().Where(x => x.RevId == revId);
        var res = query
                    .Join(db.MySubModels, pb => new { pb.Key, pb.RevId}, f => new { f.Key, f.RevId}, (pb, f) => new { MyModel = pb, Submodel = f })
                    .AsEnumerable() //get the data and map objects
                    .GroupBy(x => x.MyModel) //group them
                    .Select(group => new { MyModel = group.Key, Submodels = group.Select(x => x.Submodel).ToList() });            
    }
