    private void button_charts_Click(object sender, EventArgs e)
    {
        // I recommend changing this too, say List<string>
        ArrayList grupe = getGrupe();
        // clear the chart
        groupChart.Series.Clear();
        // loop over the groups..
        for (int g = 0; g < groups.Count; g++)
        {
            // add a series and configure it..
            // I simply set it to be of type column:
            Series ser = groupChart.Series.Add(groups[g]);
            ser.ChartType = SeriesChartType.Column;
            // now get your list of values..
            // you pick the data type!!
            List<int> date = getVanzariGrupa(grupa);
            for (int v = 0; v < date .Count; v++)
            {
                ser.Points.AddXY(v, date [v]);
            }
        }
