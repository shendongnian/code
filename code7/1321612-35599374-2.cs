    int payrowNum = 0;
    bool isValid = int.TryParse(PassPayrollNo, out payrowNum);
    if(isValid)
    {
         string sQuery = "DELETE * FROM [Employee] WHERE PayrollNo = @PayrollNo";
         OleDbCommand DoDelete = new OleDbCommand(sQuery, Conn);
         DoDelete.Parameters.AddWithValue("@PayrollNo", payrowNum);
         int rowsAffected = DoDelete.ExecuteNonQuery();
         if(rowsAffected>0)
         {
             MessageBox.Show("Success");
         }
         Conn.Close();   
         
    }
