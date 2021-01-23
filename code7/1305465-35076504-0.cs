    public static String GetTotalBalanceDue() 
        {
            decimal totalBalanceDue;
            DataTable results = new DataTable();
            string selectStatement =
                "SELECT SUM(InvoiceTotal - PaymantTotal - CreditTotal) " +
                "AS BalanceDue FROM Invoices" +
                "WHERE InvoiceTotal - PaymantTotal - CreditTotal > 0";
    
            try
            {
                using (SqlConnection connection = PayablesDBConnection.GetConnection())
                {
                    connection.Open();
    
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                         using(SqlDataAdapter adapter = new SqlDataAdapter(selectCommand))
    {
        adapter.Fill(results);
    }
                    }
                }
    
    
            }
            catch (SqlException ex)
            {
                //exceptions are thrown to the controller, then to the view
                //Please make sure that do not use MessageBox.Show(ex.Message) in the DAL
                //because it couples the DAL with the view
    
                //throw is used instead of throw ex because the former preserves the stack trace
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
