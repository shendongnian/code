    var res=(from it in filter.All
        where it.Target=="995fc819-954a-49af-b056-387e11a8875d"
        group it by new {it.Target, it.User, it.TimeStampDate} into g
        orderby g.Key.Target
        select new 
                   {
                    TimeStampDate= g.Key.TimeStampDate,
                    User=g.Key.User,
                    Usage=g.Count()
                   });
