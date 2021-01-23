    var res =  db.Table1
    //other tables, and where conditions
    .Select(x => new MyObj
    {
          //...
          Imp = x.MyTable.FirstOrDefault(y => y.date_val >= System.Data.Entity.DbFunctions.AddMonths(System.Data.Entity.DbFunctions.CreateDateTimee(x.year, x.month, 1, 0, 0, 0), 1)).Description
    })
