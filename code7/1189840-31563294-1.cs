     using (SqlDataReader dr = SQLData.checkchkbx(QuestionID))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            string TRUEorFALSE = dr["TRUEorFALSE"].ToString();
                            if (TRUEorFALSE == "True")
                            {
                                chkbxAnswer1.Checked = true;
                            }
                        }
                    }
                }
