    public ActionResult data_read([DataSourceRequest]DataSourceRequest request){
        var datacontext = db.Hive1.AsQueryable();
        var hives = (from c in datacontext).ToList();
        IQueryable<HiveViewModel> thevessel = hives.ForEach(c =>
                     select new HiveViewModel
                     {
                         //Hive 1
                         id = c.id,
                         name = c.name,
                         //Hive 2
                         location = c.Hive2.location,
                         //Hive 3
                         propulsion = c.Hive3.propulsion,
                         //Hive 4
                         bhp = c.Hive4.bhp                                                   
                                           });
    
