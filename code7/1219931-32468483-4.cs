    List<QueryTuple> tuples = new List<QueryTuple>();
    foreach (ListItem item in CheckBoxClassRegion.Items)
    {
        if (item.Selected == true)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TeamName", item.Value);
            // Make sure your connection is open before ExecuteReader
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    QueryTuple tuple = new QueryTuple
                    {
                        Date = (DateTime)dr["Date"],
                        HighSchoolName = (string)dr["HighSchoolName"],
                        HighSchoolName1 = (string)dr["HighSchoolName1"]
                    };
                    tuples.Add(tuple);
                }
            }
        }
    }
    // Finally, you set the DataSource property and call the DataBind method
    ListView1.DataSource = tuples;
    ListView1.DataBind();
