        string strResult;
        SqlDataReader sqlResult = cmd.ExecuteReader();
                while (sqlResult.Read())
                {
                   strResult  = result[0].ToString();
                }
