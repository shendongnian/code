    var res = db.Table1.ToList()
    //other tables, and where conditions
    .Select(x => new MyObj
    {
    //...
        Imp = x.MyTable.FirstOrDefault(y => y.date_val >= System.Data.Entity.DbFunctions.AddMonths(DateTime.Parse("01/" + x.month + "/" + x.year))).Description
    })
