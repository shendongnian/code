          public Sa()
        {
            SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "StoredProcedureName";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;
            var id = cmd.CreateParameter();
            id.DbType = DbType.String;
            id.Direction = ParameterDirection.Input;
            id.ParameterName = "ID";
            id.Value = yourTextBox.Text;
            cmd.Parameters.Add(id);
            var jobtype = cmd.CreateParameter();
            jobtype.DbType = DbType.String;
            jobtype.Direction = ParameterDirection.Input;
            jobtype.ParameterName = "NameOfParameter";
            jobtype.Value = yourTextBoxWithJobType.Text;
            cmd.Parameters.Add(jobtype);
            var importType = cmd.CreateParameter();
            importType.DbType = DbType.String;
            importType.Direction = ParameterDirection.Input;
            importType.ParameterName = "NameOfParameter";
            importType.Value = yourComboBox.SelectedIthem;
            cmd.Parameters.Add(importType);
            sqlConnection1.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())  // Each row from StoredProcedure
            {
                var returnObject = reader.GetString(0);
            }
            sqlConnection1.Close();
