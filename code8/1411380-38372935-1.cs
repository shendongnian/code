                catch (Exception exception)
                {
                            string query = "Insert into " + SchemaName + ".logtable (Logtextcolumn) "; -- change tablename and columns desired.
                            query += "VALUES('" + exception.ToString() + "')";
                            SqlCommand myCommand1 = new SqlCommand(query, myADONETConnection);
                            myCommand1.ExecuteNonQuery();
                    
                        Dts.TaskResult = (int)ScriptResults.Failure;
                    }
                }
