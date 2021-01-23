            con.open();
		
			sqlDs = new DataSet();
            conOpen();
            var sqlComm = new SqlCommand();
            sqlComm.Connection = con;
            sqlComm.CommandType = CommandType.Text;
            sqlComm.CommandText = query;
            sqlDa = new SqlDataAdapter(sqlComm);
            sqlDa.Fill(sqlDs);
            conClose();
			var dt = new DataTable();
            dt = sqlDs.Tables[0];
			
