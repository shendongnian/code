    decimal totalCost; // outside the event handler
    if (dgv.Rows.Count != 0)
    {
       for (int i = 1; i < dgv.Rows.Count; i++)
       {
          totalCost += Convert.ToDecimal(dgv.Rows[i].Cells[1].Value.ToString());
       }
       dgv.Rows[0].Cells[1].Value = Convert.ToDecimal( totalCost ).ToString("##,###.00");
    }
