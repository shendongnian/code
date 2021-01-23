    for (int i = 0; i < initialDataSource.Columns.Count; i++)
      {
        Series series = new Series();
        series.IsValueShownAsLabel = true;
        series.ChartType = SeriesChartType.Column;
        series.Name = initialDataSource.Columns[i].ColumnName;
        foreach (DataRow dr in initialDataSource.Rows)
        {
            string y = (string)dr[i];
            if (y != "0")
            {
                series.Points.AddXY(dr["date"].ToString(), y);
            }
        }
        Chart1.Series.Add(series);
      }
