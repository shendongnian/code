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
        string InsertSql = @"INSERT INTO Shifts 
                  (EmployeeID, Date, StartTime, EndTime, Break) 
                   values  
                   ($eid, $date, $sdate, $edate, $break)";
        SQLiteCommand InsertCom = new SQLiteCommand(InsertSql, dbcon);
        InsertCom.Parameters.Add("$eid", DbType.Int32).Value = shift.EmployeeID;
        InsertCom.Parameters.Add("$date", DbType.Date).Value = shift.Date ;
        InsertCom.Parameters.Add("$stime", DbType.Time).Value = shift.StartTime ;
        InsertCom.Parameters.Add("$etime", DbType.Time).Value = shift.EndTime;
        InsertCom.Parameters.Add("$break", DbType.Int32).Value = shift.Break;
        InsertCom.ExecuteNonQuery();
    }
