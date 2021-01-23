    public ActionResult data_read([DataSourceRequest]DataSourceRequest request)
    {
        var datacontext = db.Hive1.AsQueryable();
        var loc = c.Hive2.location;
        IQueryable<HiveViewModel> thevessel = from c in datacontext
                     select new HiveViewModel
                     {
                         //Hive 1
                         id = c.id,
                         name = c.name,
                         //Hive 2
                         location = loc,
                         //Hive 3
                         propulsion = c.Hive3.propulsion,
                         //Hive 4
                         bhp = c.Hive4.bhp                                                   
                                           };
        DataSourceResult result = thevessel.ToDataSourceResult(request);
        return Json(result);
    }
