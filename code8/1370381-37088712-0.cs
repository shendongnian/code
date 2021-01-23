    var cumulativeresult = new[] { new { Days = 0, Com = 0 }, new { Days = 1, Com = 1 } };
    var ComCount = cumulativeresult.Count();
    var result = from cr in cumulativeresult
                 orderby cr.Days
                 select new
                 {
                     Days = cr.Days,
                     Com = (from cr1 in cumulativeresult
                            where cr1.Days <= cr.Days
                            group cr1 by 1 into cr1grp
                            select
                              new
                              {
                                  Count = cr1grp.Count() + cr.Com
                              }
                               ).First().Count,
                     ComPercent = Math.Round((//double.Parse(
                               ((double)(
                               from cr1 in cumulativeresult
                               where cr1.Days <= cr.Days
                               group cr1 by 1 into cr1grp
                               select cr1grp.Count() + cr.Com).First())//.ToString())
                               / ComCount) * 100, 2
                               )
                 };
    
    var dt = new DataTable();
    dt.Columns.AddRange(new[] {new DataColumn("Days"),new DataColumn("Com"),new DataColumn("ComPercent")  });
    foreach (var item in result)
    {
        dt.Rows.Add(item.Days, item.Com, item.ComPercent);
    }
    dt.Dump();
