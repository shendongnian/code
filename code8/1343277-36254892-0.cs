     DataRow dRow = dtResult.NewRow();
     dRow[0]="average";
     for (int i = 1; i < dtGrid.Columns.Count; i++)
         {
             List<double> avgList = new List<double>();
             for (int j = 1; j < dtGrid.Rows.Count; j++)
                {
                    avgList.Add(Convert.ToDouble(dtGrid.Rows[j][i].ToString()));
                }
                double averageList = avgList.Average();
                dRow[i] = averageList.ToString("#.##");                 
         }
      dtResult.Rows.Add(dRow); 
      gridData2.DataSource = dtResult;
