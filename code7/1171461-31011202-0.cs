    // setting up the datagridview
    Table.Rows.Clear();
    Table.Columns.Clear();
    Table.Columns.Add("state", "");
    Table.Columns.Add("sanity", "SANITY");
    Table.Columns.Add("unit", "UNIT");
    Table.Columns.Add("issuesDb", "ISSUES DB");
    // filling in some data
    Table.Rows.Add("ALL PASSED", 86, 21, 2);
    Table.Rows.Add("FAILED", 7, 0, 1);
    Table.Rows.Add("Cancelled", 0, 0, 0);
    // Now we can set up the Chart:
    List<Color> colors = new List<Color>{Color.Green, Color.Red, Color.Black};
    chart1.Series.Clear();
    for (int i = 0 ; i < Table.Rows.Count; i++)
    {
        Series S = chart1.Series.Add(Table[0, i].Value.ToString());
        S.ChartType = SeriesChartType.Column;
        S.Color = colors[i];
    }
    // and fill in all the values from the dgv to the chart:
    for (int i = 0 ; i < Table.Rows.Count; i++)
    {
       for (int j = 1 ; j < Table.Columns.Count; j++)
       {
          int p = chart1.Series[i].Points.AddXY(Table.Columns[j].HeaderText, Table[j, i].Value);
       }
    }
