            public List<Item> LoadItems()
            {
                //Lets make some fake data
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Id", typeof(int)));
                dt.Columns.Add(new DataColumn("Desc", typeof(string)));
                dt.Columns.Add(new DataColumn("RateId", typeof(int)));
                dt.Columns.Add(new DataColumn("StraightTime", typeof(float)));
                dt.Columns.Add(new DataColumn("OverTime", typeof(float)));
    
                for (int x = 0; x < 100; x++)
                {
                    DataRow dr = dt.NewRow();
    
                    dr["Id"] = (x % 5);
                    dr["Desc"] = String.Format("Desc{0}", (x % 5));
                    dr["RateId"] = (x % 20);
                    dr["StraightTime"] = (x * 5.5f);
                    dr["OverTime"] = (x * 1.5f);
    
                    dt.Rows.Add(dr);
                }
    
    
                //Loading the list
                List<Item> itemList = new List<Item>();
    
                foreach (DataRow dr in dt.Rows)
                {
                    Item i = new Item();
                    i.Id = (int)dr["Id"];
                    i.Description = dr["Desc"].ToString();
                    i.Rates = new List<ItemRate>();
    
                    if (!itemList.Contains(i))
                    {
                        itemList.Add(i);
                    }
    
                    ItemRate r = new ItemRate();
                    r.Id = (int)dr["RateId"];
                    r.ItemId = (int)dr["Id"];
                    r.overTime = (float)dr["StraightTime"];
                    r.straightTime = (float)dr["OverTime"];
    
                    var f = itemList.Where(o => o.Id == r.ItemId).FirstOrDefault();
                    if (f != null)
                    {
                        if (!f.Rates.Contains(r))
                        {
                            f.Rates.Add(r);
                        }
                    }
                }
