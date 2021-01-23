    string _connectionString = "Data Source=test-PC\\tester;Initial Catalog=Chuo;Integrated Security=True;Pooling=False";
    string _selectCommand = @"SELECT * FROM Guardian WHERE STUDENT_NO = @student_no";
     
     SqlParameter parameter = new SqlParameter("@student_no", SqlDbType.Int);
     parameter.Value = Convert.ToInt32(txt_bx_guardian_student_search.Text);
                
     using (IDbConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
    
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = _selectCommand;
                        command.Parameters.Add("@student_no", SqlDbType.Int).Value = Convert.ToInt32(txt_bx_guardian_student_search.Text);
    
                        IDataReader reader = command.ExecuteReader();
    
                       
                        if (reader.Read())
                        {
                            txtBox1.Text = reader["DBFieldName1"].ToString();
                            txtBox2.Text = reader["DBFieldName2"].ToString();
                        }
                        else
                        {
                            lbl_guardian_student_search.Text = "No Guardian record exists for this student. Please enter the Guardian Information";
                        }
                    }
                }
