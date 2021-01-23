    public class TableStorage
    {
        public Table1 Table1 {get;set;}
        public Table2 Table2 {get;set;}
    }
    ...
    var results = (from t in db.Table1
                  join j in db.Table2 on t.IDCourse equals j.IDCourse
                  select new TableStorage { Table1 = t, Table2 = j }).ToList();
