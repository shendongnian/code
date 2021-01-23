    DataSet ds = new DataSet();
    adapter.fill(ds)
    if (ds.Tables[0].Rows.Count >= 1)
                        {
                            results = ds.Tables[0];
                        }
    dataTblResults.DataSource = results;
