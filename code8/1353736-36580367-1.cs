    public bool CheckStatus()
        {
            bool status = false;
            using (SqlConnection con = new SqlConnection(CS))
            {
               SqlCommand cmd = new SqlCommand("getCountStudentModule", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pathwayid", modOnpwayModIDResult);
                cmd.Parameters.AddWithValue("@userID", userIDLabel);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        string active = rdr["CntRepeatGrades"].ToString();
                        if (active == "0")
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                }
                return status;
            }
        }
