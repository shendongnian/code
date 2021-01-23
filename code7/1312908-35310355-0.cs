    var items= (from tbl1 in ds.Tables[1].AsEnumerable()
                join tbl2 in ds.Tables[2].AsEnumerable()
                  on tbl1.Field<int>("LineId") equals tbl2.Field<int>("LineID") into g
                select new Item
                {
                   LineID = tbl1.Field<int>("LineID").ToString(),
                   ItemNo = tbl1.Field<string>("ItemNo"),
                   ItemcodeList = g.Select(row => 
                      new Itemcode
                      {
                         code = row.Field<string>("code").ToString(),
                         codeValue = row.Field<string>("codeValue").ToString(),
                      }).ToList()
                }).ToList();
