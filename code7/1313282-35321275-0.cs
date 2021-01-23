    private CognexDataMan.EnumCodeKind CheckCode(String strCodeToCheck)
                {
                    String[] splitCode = strCodeToCheck.Split(new char[] { ',' });
                    String strCode = splitCode[1];
    
                    if (strCode == String.Empty)
                    {
                        // code incorrect
                        return CognexDataMan.EnumCodeKind.CODE_INCORRECT;
                    }
                    else
                    {
                        CognexDataMan.EnumCodeKind resultToReturn;
    
                        SqlConnection sqlCnn = new SqlConnection(GlobalData.CnnString);
                        SqlCommand sqlCmd = new SqlCommand("sp_CheckCode", sqlCnn);
                        sqlCmd.Parameters.AddWithValue("@Code", strCode); 
                        sqlCmd.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = "@IsUnique",
                            DbType = DbType.Int32,
                            Direction = ParameterDirection.Output
                        });
    
    
                        try
                        {
                            sqlCnn.Open();
    
                            sqlCmd.ExecuteNonQuery();
    
                            sqlCnn.Close();
    
                            // 1 means is unique
                            if ((Int32)sqlCmd.Parameters["@IsUnique"].Value == 1)
                            {
                                return CognexDataMan.EnumCodeKind.CODE_OK;    
                            }
                            else // 0 means is NOT unique
                            {
                                return CognexDataMan.EnumCodeKind.CODE_NOK;
                            }
                        }
                        catch (SqlException sqlEx)
                        {
                            // error SQL while checking code
                             return CognexDataMan.EnumCodeKind.CODE_NOK;
                        }
                        catch (Exception ex)
                        {
                            // general exception
                            return CognexDataMan.EnumCodeKind.CODE_NOK;
                        }
                    }
                    return CognexDataMan.EnumCodeKind.CODE_NOK;
                }
