    public void Export(string CmdString)
        {
            cmd = new SqlCommand(CmdString, SqlConnector.conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable("row");
            ds = new DataSet("tbl_adress");
            dt.ReadXmlSchema("..\\..\\..\\XmlDataHandler\\XmlSchema.xsd");
            SqlConnector.da.Fill(dt);
            ds.Tables.Add(dt);
            ds.WriteXml("..\\..\\..\\XmlDataHandler\\XMLFile_Export.xml");
        }
