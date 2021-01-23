    DateTime queryDate = new DateTime(2016, 05, 01);
    var value = from name in DB.tableA
                where name.column4 != "Bonus" &&
                DB.tableA.Any(x=> x.column2.Date <= queryDate && x.column1 == name.column1)
                group name by name.column1 into grp
                select new
                {
                    Column1 = grp.Key,
                    // you can use grp.key, grp.SUM(), grp.MAX(), grp.MIN(), grp.Count() ...
                    // to execute aggregate over each group
                };
