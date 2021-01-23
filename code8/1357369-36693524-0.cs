     var sqlDs = new DataSet();
     var sqlComm = new SqlCommand();
            sqlComm.Connection = sqlCon;
            sqlComm.CommandType = CommandType.Text;
            sqlComm.CommandText = query;
            sqlDa = new SqlDataAdapter(sqlComm);
            sqlDa.Fill(sqlDs);
