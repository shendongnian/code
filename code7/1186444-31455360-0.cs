    var items = Number.Select( item => new {
        A = item.Substring(0, 11),
        B = item.Substring(14, 2),
        C = item.Substring(19, 11),
        D = item.Substring(33),
        });
    var ret = (from a in Report
               join i in items
               on new {a.A, a.B, a.C, a.D} equals new {i.A, i.B, i.C, i.D}  
               where Filter.Type.Contains(a.Y) 
               select new ReportData
               {
                   X = a.X,
                   Y = a.Y,
               });
 
  
