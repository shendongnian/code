    var fromDate = date_from.Value; // tool from datetime
    // My For Loop
    for (int count = 0; count < 45; count++)
    {
        if (fromDate.DayOfWeek == DayOfWeek.Sunday)
        {
           dgv_result.Rows[count].Cells[0].Value = "";
        }
        else 
        {
           dgv_result.Rows[count].Cells[0].Value = fromDate.ToShortDateString();
        }
        fromDate = fromDate.AddDays(1);
       
    }
