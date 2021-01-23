        using (SqlConnection cnn = new SqlConnection(@"yourconnectionString")
        {
           cnn.Open();    
    
           using (SqlCommand cmd = new SqlCommand(@""Select SUM(IncCost) FROM Incomings WHERE CONVERT(DATETIME, IncDate, 103) <= GETDATE()"", cnn))
           {
               var oValue = cmd.ExecuteScalar();
               //Now the value is ready to print
               totalInc.Text = ((decimal)oValue).toString("0.00");
           }
        }
