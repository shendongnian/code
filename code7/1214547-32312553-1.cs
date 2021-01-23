    private void btn_back_Click(object sender, EventArgs e)
    {
       string path = "D:\\DatabaseInfo.xml";
       var xmlFile = XmlReader.Create(path);
       DataSet ds = new DataSet();
       ds.ReadXml(xmlFile);
       foreach (DataRow dr in ds.Tables[0].Rows)
       {
         tb_serverName.Text = dr["ServerName"].ToString();
         tb_userId.Text = dr["UserId"].ToString();
         tb_pwd.Text = dr["Password"].ToString();
         tb_dbName.Text = dr["DatabaseName"].ToString();
       }
    }
