      string ConnString = @"Provider = Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\HoliPlanData.accdb;Persist Security Info=False";
      string Query = "SELECT PayrollNo FROM [Employee] WHERE (FirstName + ' ' + LastName) = @Name"; //Will supply selected Employee's PayrollNo
    
      string getHolidayQuery = @"SELECT StartDate, EndDate, Reason 
         FROM [Holiday] 
         WHERE PayrollNo = @PayrollNo"; // Will select data from Holidays
    
      string getAbsencesQuery = @"SELECT StartDate, EndDate, Comments 
         FROM [Absences] 
         WHERE PayrollNo = @PayrollNo";
    
      var holidayData = new DataTable();
      var absenceData = new DataTable();
    
      using (OleDbConnection conn = new OleDbConnection(ConnString))
      {
        var getPayroll = new OleDbCommand(Query, conn);
        getPayroll.Parameters.AddWithValue("@name", LblName.Text);
    
        var holidaysQuery = new OleDbCommand(getHolidayQuery, conn);
        var absencesQuery = new OleDbCommand(getAbsencesQuery, conn);
        conn.Open();
    
        int GotPayroll = Convert.ToInt32(getPayroll.ExecuteScalar());   //Uses Query to Get PayrollNo
        holidaysQuery.Parameters.AddWithValue("@PayrollNo", GotPayroll);
        absencesQuery.Parameters.AddWithValue("@PayrollNo", GotPayroll);
    
        holidayData.Load(holidaysQuery.ExecuteReader());
        absenceData.Load(absencesQuery.ExecuteReader());
    
        conn.Close();
      }
    
    foreach (DataRow row in holidayData.AsEnumerable())
    {
        // here you could craft a new data table
        // however there is a discrepancy. 
        // How would the data in Holiday would relate to those
        // in absences. With the relation known, we might have 
        // gotten a single datatable from the database.
        // Probably you should give data samples.
    
    
        //    DateTime StartHold = Convert.ToDateTime(GetStart.ExecuteScalar());
        //    DateTime EndHold = Convert.ToDateTime(GetEnd.ExecuteScalar());
        //    string ReasonHold = (GetReason.ExecuteScalar()).ToString();
    
        // Above lines are sort of saying:
        //    DateTime StartHold = (DateTime)row["StartDate"];
        //    DateTime EndHold = (DateTime)row["EndDate"];
        //    string ReasonHold = (string)row["Reason"];
        // without roundtripping to database per field
    
      }
    //...
