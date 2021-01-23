    public string GetImageAsByte64String(int empno)
    {
    string conn = ConfigurationManager.ConnectionStrings["SE255_AFloresConnctionString2"].ConnectionString;
    SqlConnection connection = new SqlConnection(conn);
    string sql = "SELECT Avatar FROM Users WHERE User_ID = @ID";
    SqlCommand cmd = new SqlCommand(sql, connection);
    cmd.CommandType = CommandType.Text;
    cmd.Parameters.AddWithValue("@ID", empno);
    connection.Open();
    object img = cmd.ExecuteScalar();
    try
    {
        byte[] imgByte = (byte[])img;
        string base64String = Convert.ToBase64String(imgByte , 0, imgByte.Length);
        return  ("data:image/png;base64," + base64String);
    
    }
    catch
    {
        return null;
    }
    finally
    {
        connection.Close();
    }
    }
