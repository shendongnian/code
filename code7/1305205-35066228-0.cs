    int ColumnCount = WorkData.Columns.Count;
    string[] XPointMember = new string[ColumnCount];
    int[] YPointMember = new int[ColumnCount];
    
    for(int cnt = 0; cnt < ColumnCount; cnt++)
    {
      // This is assuming that you actually retrieve one row.
      XPointMember[cnt] = WorkData.Rows[0][cnt].ToString();
      YPointMember[cnt] = Convert.ToInt32(WorkData.Rows[0][cnt]);  
    }
    
    Chart1.Series[0].Points.DataBindXY(XPointMember, YPointMember);
