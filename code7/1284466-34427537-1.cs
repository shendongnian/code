    command2.CommandText = "INSERT INTO money (price, cardnum, checknum, [dateTime], employeeid) values(@tempPrice, @tempCreditNum, @tempCheckNum, @dateTime, @id)";
    command2.Parameters.AddRange(new OleDbParameter[] {
               new OleDbParameter("@tempPrice", TempPrice),
               new OleDbParameter("@tempCreditNum", TempCriditNum),
               new OleDbParameter("@tempCheckNum", TempCheckNum),
               new OleDbParameter("@dateTime", dateTimePickerX1.GetSelectedDateInPersianDateTime().ToShortDateString()),
               new OleDbParameter("@id", id)
    });
    command2.ExecuteNonQuery();
