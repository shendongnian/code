    while (reader.Read())
                                {
                                    EmployeeTimings empTime = new EmployeeTimings();
                                    empTime.CardNumber = reader["CardNO"].ToString();
                                    empTime.EMPId = reader["EMPID"].ToString();
                                    empTime.FirstName = reader["FirstName"].ToString();
                                    empTime.LastName = reader["LastName"].ToString();
                                    empTime.Location = reader["Location"].ToString();
                                    empTime.Trans_DateTime = Convert.ToDateTime(reader["DateTime"]);
                                    empTimingsList.Add(empTime);
                                }
