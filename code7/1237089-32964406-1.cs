    DataTable dt = new DataTable();
        dt.Columns.Add("name");
        dt.Columns.Add("value");
        XmlDocument Doc = new XmlDocument();
        Doc.Load("example.xml");
        XmlNodeList nodeList = Doc.SelectNodes("/ITEM");
        foreach (XmlNode node in nodeList)
        {
          foreach (XmlAttribute attr in node.Attributes)
          {
            string name = attr.Name;
            string value = attr.Value;
            DataRow dr = new DataRow();
            dr["name"] = name;
            dr["value"] = value;
            dt.Rows.Add(dr);
          }          
        }
        dataGridView1.DataSource = dt;
