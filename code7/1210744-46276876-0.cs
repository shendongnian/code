    DataSet ds = new DataSet();
    DataTable dt = new DataTable("notebook");
    dt.Columns.Add("is-default", typeof(bool));
    dt.Columns.Add("name", typeof(string));
    dt.Columns.Add("id", typeof(string));
    ds.Tables.Add(dt);
    ds.ReadXml(new StringReader(lcXMLSegment));
