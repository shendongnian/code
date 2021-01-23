    private void BindGrid()
    {
        string VDIListConnectionString = ConfigurationManager.ConnectionStrings["VDIListConnectionString"].ConnectionString;
        string query = "SELECT UserName, Location, Type, Active, ImageNumber FROM VDI";
        string condition = string.Empty;
        string locations = string.Empty;
        string types = string.Empty;
        foreach (ListItem item in chklocation.Items)
            locations += item.Selected ? string.Format("'{0}',", item.Value) : string.Empty;
        locations = locations.Substring(0, locations.Length - 1);
        foreach (ListItem item in chktype.Items)
            types += item.Selected ? string.Format("'{0}',", item.Value) : string.Empty;
        types = types.Substring(0, types.Length - 1);
        var subConditions = new List<string>();
        if (!string.IsNullOrEmpty(locations))
            subConditions.Add(string.Format("Location IN ({0})", locations));
        if (!string.IsNullOrEmpty(types))
            subConditions.Add(string.Format("Type IN ({0})", types));
        if (subConditions.Any())
            condition = " WHERE " + subConditions.Aggregate((c, n) => string.Format("{0} AND {1}", c, n));
        using (SqlConnection con = new SqlConnection(VDIListConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query + condition))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    cmd.Connection = con;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }
