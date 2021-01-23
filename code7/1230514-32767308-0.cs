                using (reader = tempcmd.ExecuteReader())
                {
                    var passwordlist = new List<string>();
                    while (reader.Read())
                    {
                        //get the list of passwords
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            passwordlist.Add(reader.GetValue(i).ToString());
                        }
                     }
                }
                    //if there are more than 10 passwords stored in the database remove the oldest one
                    if (passwordlist.Count > 10)
                    {
                        tempcmd.CommandText = "DELETE * FROM dbo.PasswordHistory" +
                                                              "WHERE username='" + username + "'" +
                                                              "AND password='" + passwordlist.First()                                        + "'";
                        tempcmd.ExecuteNonQuery();
                        passwordlist.RemoveAt(0);
                    }
                    //check and see if that password has already been used, if so throw an error
                    foreach (var p in passwordlist)
                    {
                        if (p == pass)
                        {
                            throw new ArgumentException("Unable to create password. Password does not meet the history requirements of the domain.");
                        }
                    }
  
