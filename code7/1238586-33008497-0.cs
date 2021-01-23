    DataTable dt = new DataTable();
    using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
    {
        connection.Open();
        System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
        command.Connection = connection;
        command.CommandText = @"SELECT * FROM  TableName";
        System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(command);
        adapter.Fill(dt);
    }
    MemoryStream ms = new MemoryStream();
    dt.WriteXml(ms, XmlWriteMode.IgnoreSchema);
    ms.Seek(0, SeekOrigin.Begin);
    StreamReader sr = new StreamReader(ms);
    string xml = sr.ReadToEnd();
    ms.Close();
    return xml;
