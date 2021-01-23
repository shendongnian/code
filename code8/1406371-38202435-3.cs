    string query = "select DISTINCT DATEPART(YEAR, dbo.News.DateUpdate) as Year, "
                 + "DATEPART(YEAR, dbo.News.DateUpdate) as Month"
                 + "from dbo.News";
    
    List<DataHolder> A = db.News.SqlQuery(query).ToList();
    
    var results = (from a in A
                    group a by a.Year into grp
                    select new
                    {
                        Year = grp.Key,
                        Months = grp.Select(x => x.Month).ToList()
                    }).ToList();
