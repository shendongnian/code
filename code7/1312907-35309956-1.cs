            var itemCodes = ds.Tables[2].AsEnumerable().Select(dataRow => new Itemcode
            {
                LineID = dataRow.Field<string>("LineID"),
                code = dataRow.Field<string>("code"),
                codeValue = dataRow.Field<string>("code")
            }).ToLookup(ic => ic.LineID);
            var lines = ds.Tables[1].AsEnumerable()
                .Select(dataRow => new {dataRow, lineID = dataRow.Field<string>("LineID")})
                .Select(item => new Item
                {
                    LineID = item.lineID,
                    ItemNo = item.dataRow.Field<string>("ItemNo"),
                    ItemcodeList = itemCodes[item.lineID].ToList()
                }).ToList();
