    SearchResult myobj = (SearchResult)js.Deserialize(objText, typeof(SearchResult));
                if (myobj.data != null && myobj.data.Count > 0)
                {
                    DataTable dt = ToDataTable(myobj.data);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            foreach (DataColumn dc in dt.Columns)
                            {
                                Console.WriteLine(item[dc]);
                            }
    
                        }
                    }
                }
