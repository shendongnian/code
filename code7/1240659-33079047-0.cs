    DateTime TotalTimeOfAllRows;
   
    for (c= 0; c < DataGridView1.Rows.Count; c++)
    {
        DateTime timeIn = DataGridView1.Rows[c].FindControl("txtTimeIn").Text;
      DateTime timeOut = DataGridView1.Rows[c].FindControl("txtTimeOut").Text;
      // Here Compute Datetime TotalTime
      DataGridView1.Rows[c].FindControl("txtTotalTime").Text = TotalTime.ToString();
      // Here Add TotalTime to TotalTimeOfAllRows     
  
    }
    //If TotalTimeOfAllRows Textbox is in Datagridview too
     DataGridView1.Rows[DataGridView1.Rows.Count-1].FindControl("txtTotalTimeOFAllRows").Text = TotalTimeOfAllRows.ToString();
        
