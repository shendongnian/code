    protected DataTable DataGrid1(string FirstDate, string SecondDate)
       {
            DateTime fFirstDate;
            DateTime sSecondDate;
            DataTable dt = new Datatable(); 
            DataTable dt2 = new DataTable();
    
            //Check Valid Date Format
    
            if (DateTime.TryParse(FirstDate, out fFirstDate) && DateTime.TryParse(SecondDate, out sSecondDate))
            {
                SqlConnection con = new SqlConnection(GetConnectionString());
                try
                {
                   con.Open();
                   string sqlStatement = "SELECT * @DateFrom and @DateTo"
                   SqlCommand cmd = new SqlCommand(SqlStatement, con);
                   cmd.Parameters.AddWithValue("@DateFrom", fFirstDate)
                   cmd.Parameters.AddWithValue("@DateTo", sSecondDate)
                   sqlDataAdapter sql_adapter = new SqlDataAdapter(cmd);
                   sql_adapter.Fill(dt);
                  return dt;
                 catch (System.Data.SqlClient.SqlException ex)
                 {
                    string msg = "Error"
                    msg += ex.Message;
                    throw new Exception(msg);
                 }
                 finally
                 {
                    con.Close();
                 }
          }
       }
