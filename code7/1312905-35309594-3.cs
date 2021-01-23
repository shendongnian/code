    List<Item> items = ds.Tables[1].AsEnumerable().Select(dataRow => new Item
                        {
                            LineID= Convert.ToString(dataRow.Field<int>("LineID")),
                            ItemNo= dataRow.Field<string>("ItemNo"),
                            ItemcodeList = ds.Tables[2].AsEnumerable().Where(ic=>ic.Field<int>("LineId")==dataRow.Field<int>("LineID")).Select(row => new Itemcode
                            {
                                code= Convert.ToString(row.Field<string>("code")),
                                codeValue = Convert.ToString(row.Field<string>("codeValue")),
                            }).ToList()
                        }).ToList();
