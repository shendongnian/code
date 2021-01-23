            string connectionString = "Provider=OraOLEDB.Oracle;Data Source=" + tableSpace + ";User Id=" + userName + ";Password=" + password + ";";
            System.Data.OleDb.OleDbConnection cnn = new System.Data.OleDb.OleDbConnection(connectionString);
            cnn.Open();
            System.Data.OleDb.OleDbDataAdapter Dadpt = new System.Data.OleDb.OleDbDataAdapter(readText, cnn);
            DataSet ds = new DataSet();
            Dadpt.Fill(ds);
            cnn.Close();
