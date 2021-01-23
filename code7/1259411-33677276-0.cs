    public List<NameAddrmark> GetNameRespCommentData(string respid)
    {
        List<NameAddrmark> cmsList = new List<NameAddrmark>();
        SqlConnection connection = new SqlConnection("");
        string sql = "SELECT top 2 * FROM dbo.RESPONDENT_COMMENT WHERE respid = " + GeneralData.AddSqlQuotes(respid) + " and USRNME = " + GeneralData.AddSqlQuotes(UserInfo.UserName) + " order by COMMDATE ASC";
        SqlCommand command = new SqlCommand(sql, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
            while (reader.Read())
            {
                NameAddrmark cms = new NameAddrmark();
                cms.Id = respid;
                cms.Date8 = reader["COMMDATE"].ToString();
                cms.Usrnme = reader["USRNME"].ToString();
                cms.Marktext = reader["COMMTEXT"].ToString();
                cmsList.Add(cms);
            }
        } catch (SqlException ex)
        {
            throw ex;
        } finally
        {
            connection.Close();
        }
        return cmsList;
    }
