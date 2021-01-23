    foreach (string line in lines)
    {
        string[] fields = line.Split(';');
        shift.EmployeeID = Int32.Parse(fields[0]);
        DateTime dt = DateTime.ParseExact(fields[1], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
        shift.Date = dt;
        DateTime st = DateTime.ParseExact(fields[2], "HHmm", System.Globalization.CultureInfo.InvariantCulture);
        shift.StartTime = st;
        DateTime et = DateTime.ParseExact(fields[3], "HHmm", System.Globalization.CultureInfo.InvariantCulture);
        shift.EndTime = et;
        shift.Break = Int32.Parse(fields[4]);
        using (var con = new SQLiteConnection { ConnectionString = "ConnectionString" })
        {
            using (var command = new SQLiteCommand { Connection = con })
            {
               con.Open();
               
               try
               {
                  command.CommandText = @"INSERT INTO Shifts 
                                          (EmployeeID, Date, StartTime, EndTime, Break) 
                                          VALUES (@eid, @date, @stime, @etime, @break)";
                 command.Parameters.AddWithValue("@eid", shift.EmployeeID);
                 command.Parameters.AddWithValue("@date", shift.Date);
                 command.Parameters.AddWithValue("@stime", shift.StartTime);
                 command.Parameters.AddWithValue("@etime", shift.EndTime);
                 command.Parameters.AddWithValue("@break", shift.Break);
                 command.ExecuteNonQuery();
                 command.Parameters.Clear();
               }
               catch(SQLiteException ex)
               {
                  throw ex; 
               }
            }
        }
        
    }
