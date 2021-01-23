    var s = "samedi 14 mars 2015";
    var dt = DateTime.Parse(s, CultureInfo.GetCultureInfo("fr-FR"));
    
    using (var con = new SqlConnection(conString))
    using (var cmd = con.CreateCommand())
    {
        cmd.CommandText = "INSERT INTO [test] ([Datedes]) VALUES(@date)";
        cmd.Parameters.Add("@date", SqlDbType.Date).Value = dt;
        con.Open();
        cmd.ExecuteNonQuery();
    }
