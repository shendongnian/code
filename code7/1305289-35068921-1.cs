     var list = rdr.Select(x => {
         dynamic itm = new ExpandoObject();
         itm.Add(rdr.GetName(0), x[0];
         itm.Add(rdr.GetName(1), x[1];
         itm.Add(rdr.GetName(2), x[2];
         return itm;
     }).ToList();
