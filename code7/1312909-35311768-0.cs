    List<Item> items =
                ds.Tables[0].AsEnumerable().GroupJoin(
                ds.Tables[1].AsEnumerable(),
                tab1 => tab1.Field<int>("LineID"),
                tab2 => tab2.Field<int>("LineID"),
                (tab1, tab2) => new Item
                            {
                                LineID = Convert.ToString(tab1.Field<int>("LineID")),
                                ItemNo = tab1.Field<string>("ItemNo"),
                                ItemcodeList = tab2.AsEnumerable().SelectMany(codes=> 
                                    new List<Itemcode>                                   
                                    {
                                        new Itemcode { code = codes.Field<string>("Code")} 
                                    }
                                ).ToList()
                            }
                ).ToList();
