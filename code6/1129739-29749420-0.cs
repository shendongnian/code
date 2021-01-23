            command.CommandText = "INSERT INTO Tracker(INum,IName,IVio,IDate,ISanc,ITodayDate,IGnG) values(@txtNumber,@txtName,@txtVio,@calDate,@txtSan,@calTodayDate,@txtGnG)";
            command.Parameters.Add(new OleDbParameter("@txtNumber", txtNumber);
            command.Parameters.Add(new OleDbParameter("@txtName", txtName);
            command.Parameters.Add(new OleDbParameter("@txtVio", txtVio);
            command.Parameters.Add(new OleDbParameter("@calDate", calDate);
            command.Parameters.Add(new OleDbParameter("@txtSan", txtSan);
            command.Parameters.Add(new OleDbParameter("@calTodayDate", calTodayDate);
            command.Parameters.Add(new OleDbParameter("@txtGnG", txtGnG);
            command.ExecuteNonQuery();
