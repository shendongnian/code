            public int insertdetails(string command, params string[] parameters)
            {
                SqlCommand sqlCom = new SqlCommand()
                {
                    Connection = sqlCon,
                };
    
                string insertedValues = String.Empty;
    
                if(parameters.Any())
                {
    
                int counter = 1;
                foreach(var paramVal in parameters)
                {
                    string paramName = "@param" + counter++;
    
                    sqlCom.Parameters.AddWithValue(paramName, paramVal);
    
                    insertedValues += paramName + ",";
                }
    
                insertedValues = insertedValues.TrimEnd(',');
    
                insertedValues = String.Format(" VALUES ( {0} )", insertedValues);
                    }
    
                sqlCom.CommandText = String.Format("{0} {1}", command, insertedValues);
    
                return sqlCom.ExecuteNonQuery();
            }
