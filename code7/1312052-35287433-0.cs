     foreach (var _iterator in ListBoxSelectedDates.Items)                 // here "lstDate" is name of your list where you store all date.
                {
                    string item = _iterator.ToString();
                    string q = "select count(*) from event_calendar where _date='" + Convert.ToDateTime(item).ToString("yyyy-MM-dd") + "'";
                    MySqlCommand cmd = new MySqlCommand(q, conn);
                    conn.Open();
                    if ((long)(cmd.ExecuteScalar() ?? 0) == 0)
                    {
    
                        strBody += i + ". " + Convert.ToDateTime(item).ToString("dd-MMM-yyyy") + ", " + Convert.ToDateTime(item).DayOfWeek + "  : Leave <br>";
                        i++;
                    }
                    else
                    {
    
                        strBody += i + ". " + Convert.ToDateTime(item).ToString("dd-MMM-yyyy") + ", " + Convert.ToDateTime(item).DayOfWeek + "  : Holiday <br>";
                        i++;
                    }
    
                    conn.Close();
                }
