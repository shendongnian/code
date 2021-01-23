    try {
      using (OleDbConnection con = new OleDbConnection(DatabaseConnection.ConString)) {
        con.Open();
    
        using (OleDbCommand cmd = new OleDbCommand(DatabaseConnection.Commandstring, con)) {
          using (var reader = cmd.ExecuteReader()) {
            if (reader.Read()) // you have to read
              txt_TotalTime.Text = String.Format("Total Time: ", reader.GetValue(0));
          }
        }
      }
    }
    catch (DbException ex) { // Bad style: do not catch ALL the exceptions
      Debug.WriteLine("Error Selecting Time from Database " + ex.Message);
    }
