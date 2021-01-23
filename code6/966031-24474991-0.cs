    private void button_charts_Click(object sender, EventArgs e)
    {
        // I recommend changing this to a Lsit<string>
        ArrayList grupe = getGrupe();
        // clear the chart
        groupChart.Series.Clear();
        // your pick of colors..
        GroupColors = new List<Color>() 
            { Color.DarkGreen, Color.DarkSalmon, Color.DarkOrange, Color.DarkOliveGreen };
        // loop over the groups..
        for (int g = 0; g < groups.Count; g++)
        {
            // add a series of type column..
            Series ser = groupChart.Series.Add(groups[g]);
            ser.Color = GroupColors[g];
            ser.ChartType = SeriesChartType.Column;
            // now get your list of values..
            // you pick the data type!!
            List<int> date = getVanzariGrupa(grupa);
            for (int v = 0; v < date .Count; v++)
            {
                ser.Points.AddXY(v, date [v]);
            }
        }
