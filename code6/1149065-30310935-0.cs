    Dictionary<string, string> dict1 = new Dictionary<string, string>();
    foreach (DataRow r in my.Tables[0].Rows)
    {
        foreach (DataColumn c in my.Tables[0].Columns)
        {
            string spec = r[c].ToString();
            string href = spec.Substring(spec.IndexOf("href=");
            href = href.Trim("\"").Substring(0, spec.IndexOf("\""));
            ....
            dict1.Add(href, val);
        }
    }
    ddl1.DataSource = dict1;
    ddl1.DataBind();
