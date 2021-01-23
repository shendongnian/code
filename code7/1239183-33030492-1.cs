         for (count = 0; count < 45; count++)
    {
        fromDate = fromDate.AddDays(1); 
    
        if (fromDate.DayOfWeek == DayOfWeek.Sunday)
        {
            // Remove the sunday code        
            fromDate = fromDate.AddDays(1); 
        }
      
        dgv_result.Rows[count].Cells[0].Value = fromDate.ToShortDateString();
    }
