            var itemCodes = (
                from dataRow in ds.Tables[2].AsEnumerable()
                select new Itemcode
                {
                    LineID = dataRow.Field<string>("LineID"),
                    code = dataRow.Field<string>("code"),
                    codeValue = dataRow.Field<string>("code")
                }).ToLookup(ic => ic.LineID);
            var lines = (
                from dataRow in ds.Tables[1].AsEnumerable()
                let lineID = dataRow.Field<string>("LineID")
                select new Item
                {
                    LineID = lineID,
                    ItemNo = dataRow.Field<string>("ItemNo"),
                    ItemcodeList = itemCodes[lineID].ToList()
                }).ToList();
