    protected void btnTestDb_Click(object sender, EventArgs e)
    {
        string result = TestConnection();
        Response.Write(result);
    }
    private string TestConnection()
    {
        try
        {
            using(SqlConnection connection = new SqlConnection("...."))
            {
                 connection.Open();
                 return "Connection opened correctly";
            }
        }
        catch(Exception ex)
        {
            return "Error opening the connection:" + ex.Message;
        }
    }
