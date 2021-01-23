    var objlist = (
        From a in Contex.UserName
        From b in Contex.tbl1.where(x=>x.UserName==a.UserName).DefaultEmpty()
        From c in Contex.tbl2.where(x=>x.UserName==a.UserName).DefaultEmpty()
        From d in Contex.tbl3.where(x=>x.UserName==a.UserName).DefaultEmpty()
        group a by a.UserName into pg       
        Select new {
            UserName = pg.UserName,tbl1count=pg.Count(x=>x.tbl1id)
            ,tbl2Date = pg.max(x=>x.CreatedDate)
            ,tbl3Date = pg.max(x=>x.SomeDate)
            ,SomeDate = pg.max(x=>x.DteRegistered)
    }).ToList();
