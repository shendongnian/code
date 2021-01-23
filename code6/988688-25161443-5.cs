    int RowIndex = Convert.ToInt32(row.RowIndex);
    //lblSelectionMessage.InnerText = RowIndex.ToString();
    foreach(GridViewRow rw in GridViewSmsComplaints.Rows)
    {
       if(rw.RowIndex != RowIndex)
       {
          rw.Enabled = false;
       }
    }
