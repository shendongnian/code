    IExcelQueryFactory fact = new ExcelQueryFactory(path);
    var query = from r in fact.Worksheet(0)
                select r;
    IList<MyModel> models = new List<MyModel>();
    foreach(var row in query){
        MyModel m = new MyModel();
        foreach(String colName in MyColMapping.Keys){
            p.GetType().GetProperty(colName).SetValue(p, row[ColMapping[colName]]);
        }
        foreach(ExtraProperty p in PMapping.Keys){
            if(row[PMapping[p]].Equals("yes"))
                m.ExtraProperties.Add(p);
        }
        models.add(m);
    }
