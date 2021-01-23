    public bool IsBadWord(string Word)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
        string sql = "select top 1 * from tblword where Word=@Word";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.Add("@Word");
    
        foreach (var element in Word.Split())
        {
            cmd.Parameters[0].Value = element;
            if(cmd.ExecuteScalar()!=null)
                return true;
        }
    
        return false;
    }
