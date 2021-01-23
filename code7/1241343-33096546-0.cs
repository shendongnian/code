    var q = (from row in db.table1
            group row by new { row.id, row.name } into grp
            select new
            {
                grp.Key.id,
                grp.Key.name,
                sum = grp.Sum(s => s.calorie)
            }).ToList();
    foreach(var item in q)
    {
        var e = new db.table2Entity
        {
            id = item.id,
            name = item.name,
            totalcalorie = item.sum
        };
        db.Table2.AddObject(e);      
    }
    db.SaveChanges();
