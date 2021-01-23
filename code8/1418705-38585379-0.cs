                using (SqlConnection sqlConn = new SqlConnection("CONNECTION STRING"))
                {
                  DataSet ds = new DataSet();
                  SqlCommand sqlCmd = sqlConn.CreateCommand();
                  sqlConn.Open();
                  SqlDataAdapter SQA_DataAdapter = new SqlDataAdapter(sqlCmd);
                  SQA_DataAdapter.SelectCommand = new SqlCommand("SELECT Id, Ime FROM Unajmljivaci WHERE Aktivan = 0", sqlConn);
                  SQA_DataAdapter.Fill(ds, "Table");
                  if (ds != null)
                    if (ds .Tables.Count > 0)
                    {
                      cmbUnajmljivaci.ValueMember = "Id";
                      cmbUnajmljivaci.DisplayMember = "Ime";
                      cmbUnajmljivaci.DataSource = ds.Tables[0];
                    }
                  sqlConn.Close();
                }
