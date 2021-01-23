    public bool SaveChatSectionUserMapping(List<Sections> lstSections, int customerId)
            {
                con = new SqlConnection(connectionString);
                bool isUpdated = false;
                try
                {
                    string xmlString = string.Empty;
                    xmlString = XMLOperations.WriteXML(lstSections);
                    SqlCommand cmd = new SqlCommand("spUpdateSections", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@XMLData", SqlDbType.Xml).Value = xmlString;
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = customerId;
                    SqlParameter param = new SqlParameter();
                    param.SqlDbType = SqlDbType.Bit;
                    param.Direction = ParameterDirection.Output;
                    param.ParameterName = "@Result";
                    cmd.Parameters.Add(param);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    isUpdated = (param.Value != DBNull.Value) ? Convert.ToBoolean(param.Value) : false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                return isUpdated;
            }
