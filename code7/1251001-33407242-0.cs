                        mySqlCommand.Parameters.Add("Username", MySqlDbType.VarChar);
                        mySqlCommand.Parameters["Username"].Direction = System.Data.ParameterDirection.Input;
                        mySqlCommand.Parameters["Username"].IsNullable = true;
                        if (!string.IsNullOrEmpty(objUsers.Name))
                            mySqlCommand.Parameters["Username"].Value = objUsers.Name;
