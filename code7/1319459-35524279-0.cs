        using (SqlConnection cnn = new SqlConnection(@"yourconnectionString")
        {
           cnn.Open();    
    
           using (SqlCommand cmd = new SqlCommand(@""Select SUM(IncCost) FROM Incomings WHERE CONVERT(DATETIME, IncDate, 103) <= GETDATE()"", cnn))
           {
           }
        }
