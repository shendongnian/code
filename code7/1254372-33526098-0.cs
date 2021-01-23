        public void SampleCode()
        {
            // some code
            foreach (DataRow row in myDataSet.Tables["Query"].Rows)
            {
                // For each Row add a new series
                string seriesName = row["SalesRep"].ToString();
                Chart1.Series.Add(seriesName);
                Chart1.Series[seriesName].ChartType = SeriesChartType.Line;
                Chart1.Series[seriesName].BorderWidth = 2;
                for (int colIndex = 1; colIndex < myDataSet.Tables["Query"].Columns.Count; colIndex++)
                {
                    // For each column (column 1 and onward) add the value as a point
                    string columnName = myDataSet.Tables["Query"].Columns[colIndex].ColumnName;
                    int YVal = (int)row[columnName];
                    Chart1.Series[seriesName].Points.AddXY(columnName, YVal);
                }
            }
            DataGrid.DataSource = myDataSet;
            DataGrid.DataBind();
        }
