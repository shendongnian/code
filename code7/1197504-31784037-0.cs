    try
                {
                    if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        sqlConn.Open();
                        using (SqlCommand cmd = new SqlCommand("GetAppForm", sqlConn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);                       
                            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                            //SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                            while (dataReader.Read())
                            {
                                OwnerField.Text = dataReader["Owner"].ToString();
                                OdBookNoField.Text = dataReader["OD"].ToString();
                                PdLocField.Text = dataReader["pd"].ToString();
                                StatementNoField.Text = dataReader["Statmnt"].ToString();
                                ApplicationNoField.Text = dataReader["AppNo"].ToString();
                                AppDateField.Text = dataReader["AppDate"].ToString();
                                areaField.Text = dataReader["Area"].ToString();
                                areaNoField.Text = dataReader["AreaNo"].ToString();
                                blockNoField.Text = dataReader["BlockNo"].ToString();
                                streetNoField.Text = dataReader["StreetNo"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write("No Connection!!");
                }
                finally
                {
                    sqlConn.Close();
                }
