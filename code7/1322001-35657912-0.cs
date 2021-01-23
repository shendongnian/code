       for (int i = 0; i < rowsCount; i++)
                {
                    if(dbChequeGrid.Rows[i].Cells[0].Value != null){
                        string StrQuery = "INSERT INTO cust (clientname,clientaddress,clientfathername)VALUES (@id,@CourseName,@Credits)";
                        comm.CommandText = StrQuery;
                        comm.Parameters.AddWithValue("@id", dbChequeGrid.Rows[i].Cells[0].Value);
                        comm.Parameters.AddWithValue("@CourseName", dbChequeGrid.Rows[i].Cells[1].Value);
                        comm.Parameters.AddWithValue("@Credits", dbChequeGrid.Rows[i].Cells[2].Value);
                        if (comm.ExecuteNonQuery() > 0)
                        {
                            rowsInserted++;
                        }
                        comm.Parameters.Clear();
                    }else{
                         //do some sort of error handling
                    }
                }//end of for loop
