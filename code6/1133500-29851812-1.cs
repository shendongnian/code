    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
      this.StartDate = dateTimePicker1.Value.Date;
    }
    private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
    {
      this.EndDate = dateTimePicker1.Value.Date;
    }
    private void button2_Click(object sender, EventArgs e)
    {
      DataTable results = GetCustomerRecords.GetCustomerRecords(this.StartDate, this.EndDate);
    }
    
    public static class GetCustomerRecords
    {
      public static DataTable GetCustomerRecords(DateTime date, DateTime date2)
      {
        DataTable dt = new DataTable();
        string connStr = ConfigurationManager.ConnectionStrings["YourConnStr"].ConnectionString;
        string query = @"select 
                          value1, 
                          value2, 
                          value3, 
                          date2 
                         from TABLE 
                         where date1 BETWEEN 
                         CAST(@startDate AS DATE) and CAST(@endDate AS DATE)";
        using(SqlConnection conn = new SqlConnection(connStr))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
          cmd.Parameters.AddWithValue("@startDate", date);
          cmd.Parameters.AddWithValue("@endDate", date2);
          SqlDataAdapter adapter = new SqlDataAdapter();
          adapter.Fill(dt);
        }
         return dt;
       }
    }
