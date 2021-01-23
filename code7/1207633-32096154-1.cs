        public int InsertAndRetrieveClientRefId(string clientRefTypeName)
        {
            int id = GetIdIfRecordExists(clientRefTypeName);
            if (id == 0)
            { 
                // insert logic here
                id = GetIdIfRecordExists(clientRefTypeName);
            }
            return id;
        }
        public int GetIdIfRecordExists(string clientRefTypeName)
        {
            int id = 0;
            string command = "select id from ClinRefFileTypeMaster where ClinRefTypeName = @ClinRefTypeName";
            SqlParameter nameParameter = new SqlParameter("@ClinRefTypeName", System.Data.SqlDbType.NVarChar, 10) { Value = clientRefTypeName };
            using (SqlConnection connection = new SqlConnection("ConnectionString"))
            {
                using (SqlCommand cmd = new SqlCommand(command))
                {
                    cmd.Parameters.Add(newParameter);
                    connection.Open();
                    cmd.Connection = connection;
                    int.TryParse(cmd.ExecuteScalar().ToString(), out id);
                }
            }
            
            return id;
        }
