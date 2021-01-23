    protected internal string GetSingleValue_String(String spname, Object entity)
            {
                Object res = new Object();
                String conString = String.Empty;
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(spname, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (entity != null)
                    {
                        SqlCommandBuilder.DeriveParameters(cmd);
                        PropertyInfo entitymember = default(PropertyInfo);
                        foreach (SqlParameter _param in cmd.Parameters)
                        {
                            if (_param.Direction == ParameterDirection.Input)
                            {
                                entitymember = entity.GetType().GetProperty(_param.ParameterName.Replace("@", ""));
                                var entityValue = entitymember.GetValue(entity, null);
                                String _paramvalue = entityValue != null ? entityValue.ToString() : null; 
                                _param.Value = (string.IsNullOrEmpty(_paramvalue) || _paramvalue == string.Empty ? null : _paramvalue);
                            }
                        }
                    }
                    res = cmd.ExecuteScalar();
                    cmd.Connection.Close();
                    entity = null;
                    cmd = null;
                    if(res==null)
                        res = "";
                    else if (String.IsNullOrEmpty(res.ToString()))
                        res = "";
                    return res.ToString();
                }
            }
