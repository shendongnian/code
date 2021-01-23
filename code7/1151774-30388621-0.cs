    var mainTableDS = new DataSet();
    String query = String.Format("exec {0} {1}", StoredProcedure, sampleproc);  //possibly vulnerable to SQL Injection attacks!
    using (var  conn = new SqlConnection(ConfigurationSettings.AppSettings["Constring"]))
    using (var mainTableAdapter = new SqlDataAdapter(query, conn))
    {
        mainTableAdapter.Fill(mainTableDS);
    }
    return mainTableDS;
