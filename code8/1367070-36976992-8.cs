    case 6:
                                con.Open();
                                string query = "SELECT count (  sixth  ) FROM  Monday  ";
                                SqlCommand cmd3 = new SqlCommand(query, con);
                                Int32 count = (Int32)cmd3.ExecuteScalar();
                                if (count == 0)
                                {
                                    cmd = new SqlCommand("INSERT INTO Monday (sixth) values (@value)", con);
    
                                }
                                else
                                {
                                    query = "SELECT top 1 sixth FROM Monday";
                                    cmd = new SqlCommand(query, con);
                                    string dbValue = (string)cmd.ExecuteScalar();
                                    if (dbValue != null && dbValue != string.Empty)
                                    {
                                        value += ";" + dbValue;
                                        //value += s.SubjectName;
                                        cmd = new SqlCommand("UPDATE  Monday set [sixth] = @value", con);
        
                                    }
                                }
                                cmd.Parameters.AddWithValue("value",value);
                                cmd.ExecuteNonQuery();
                                con.Close();
                                break;
