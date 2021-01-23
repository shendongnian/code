       DataRow dAvgRow = dtResult.NewRow();
            DataRow dMinRow = dtResult.NewRow();
            dAvgRow[0]="average";
            dMinRow[0] = "Minimum";
            for (int i = 1; i < dtGrid.Columns.Count; i++)
            {
                List<double> avgList = new List<double>();
                for (int j = 1; j < dtGrid.Rows.Count; j++)
                {
                    avgList.Add(Convert.ToDouble(dtGrid.Rows[j][i].ToString()));
                }
                double averageList = avgList.Average();
                dAvgRow[i] = averageList.ToString("#.##");     
                dMinRow[i]=avgList.Min();
            }
            dtResult.Rows.Add(dAvgRow);
            dtResult.Rows.Add(dMinRow); 
      gridData2.DataSource = dtResult;
