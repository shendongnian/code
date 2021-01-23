    string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Shamila Stuff\campus\semester 2\comp 1551-Application and Web Developement\asp\fwp\fwp\FwpDatabase.accdb"; // put your path
    myConnection = new OleDbConnection(connString);
    
    string query = "select * from payment where memberID= '"+ txtMemberID.Text + "'";
     if (myConnection == null)
                    myConnection = GetConnection();
                OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
    
                try
                {
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
    
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                finally
                {
                    myConnection.Close();
                }
                try
                {
                    myConnection.Open();
                    OleDbDataReader reader = myCommand.ExecuteReader();
    
                    if (reader.HasRows == true)
                    {
                        reader.Read();
                        
                        string myQuery1 = Chart1.Series["Tax History"].Points.AddXY(reader["date"].ToString(), reader["taxAmount"].ToString());
    
                        myCommand = new OleDbCommand(myQuery1, myConnection);
                        myCommand.ExecuteNonQuery();
                        reply = true;
    
                    }
                    else
                    {
                        reply = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    myConnection.Close();
                }
