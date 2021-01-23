    var maxTest= data.AsEnumerable()
                      .GroupBy(g=> g.Field<string>("SerialNumber"))
                      .Select(d=> new
                      {
                         SerialNumber = g.Key
                         Test = g.Max(g.Field<Int16>("Field"))
                      };
    
    var maxRows = from d in data.AsEnumerable()
                  join m in maxTest
                  on new { S = d.Field<string>("SerialNumber"), T = d.Field<Int16>("Test") } 
                  equals new { S = m.SerialNumber, T = m.Test }
                  select d;
 
