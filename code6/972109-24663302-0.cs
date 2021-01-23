    class MyResultItem
    {
        public string FieldOne { get; set; }
        public string FieldTwo { get; set; }
    }
    IQueryable<MyResultItem> result1 = from t in db.table1 select new MyResultItem {
        FieldOne = t.FieldOne,
        FieldTwo = t.FieldTwo
    };            
    IQueryable<MyResultItem> result2 = from g in db.table2 select new MyResultItem {
        FieldOne = g.FieldOne,
        FieldTwo = g.FieldTwo
    };            
    IEnumerbale<MyResultItem> combinedTable = result1.Union(result2).ToList();
