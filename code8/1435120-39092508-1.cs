    public void ProcessRequest(HttpContext context)
    {
        string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        using(var conn = new SqlConnection(connection))
        {
            using (var comm = new SqlCommand("SELECT FileId, [FileName], ContentType, Data FROM Files WHERE FileId=2",conn))
            {
                using(var da = new SqlDataAdapter(comm))
                {
                    var dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);
                    conn.Close();
                    byte[] Data = (byte[])dt.Rows[0][3];
                    context.Response.BinaryWrite(Data);
                    context.Response.Flush();
                }
            }
        }
    }
