     public bool IsExists(int iYear,int iMonth)
            {
                bool check = false;
                string allDays = "1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 24";
                try
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["aConn"].ToString());
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    SqlCommand cmd = new SqlCommand("select ProjectId,CalendarDate from UserActivity where YEAR(CalendarDate) = " + iYear + " and MONTH(CalendarDate) = " + iMonth + "");
                    cmd.Connection = conn;
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<KeyValuePair<string, string>> allValue = new List<KeyValuePair<string, string>>();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            allValue.Add(new KeyValuePair<string, string>(reader[0].ToString(), reader[1].ToString()));
                        }
                    }
                    string[] strSplit = allDays.Split(new char[] {' '});
                    foreach (var s in strSplit)
                    {
                        string _currentDate = Convert.ToDateTime(string.Format("{0}/{1}/{2}", s, iMonth, iYear)).ToShortDateString();
                        foreach (KeyValuePair<string, string> kv in allValue)
                        {
                            if (_currentDate == Convert.ToDateTime(kv.Value).ToShortDateString())
                            {
                                check = true;
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return check;
            }
