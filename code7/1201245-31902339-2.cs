    public int insertdetails(string command, params string[] parameters)
    {
        SqlTransaction trans = null;
    
        try
        {
            trans = getconnection().BeginTransaction("trInsert");
            SqlCommand sqlCom = new SqlCommand()
            {
                Connection = con,
                Transaction = trans
            };
    
    
            // Start Building the Parameterized Command
            string insertedValues = String.Empty;
    
            if (parameters.Any())
            {
                int counter = 1;
                foreach (var paramVal in parameters)
                {
                    string paramName = "@param" + counter++;
    
                    sqlCom.Parameters.AddWithValue(paramName, paramVal);
    
                    insertedValues += paramName + ",";
                }
    
                insertedValues = insertedValues.TrimEnd(',');
    
                insertedValues = String.Format(" VALUES ( {0} )", insertedValues);
            }
    
            sqlCom.CommandText = String.Format("{0} {1}", command, insertedValues);
    
            int resCount = sqlCom.ExecuteNonQuery();
    
            if (resCount > 0)
            {
                trans.Commit();
                return 1;
            }
            else
            {
                trans.Rollback("trInsert");
                return 0;
            }
        }
        catch (Exception ex)
        {
            // Exception Handling
            if (trans != null)
                trans.Rollback();
            return 0;
        }
    }
