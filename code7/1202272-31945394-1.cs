        chartSchedule .Series.Clear();
        ChartArea CA = chartSchedule .ChartAreas[0];
        chartSchedule.Titles.Add("Agent / Task Schedule");
        chartSchedule.ChartAreas[0].AxisX.Title = "Agent";
        chartSchedule.ChartAreas[0].AxisY.Title = "Time";
        // our only Series
        Series agentSeries = chartSchedule.Series.Add(" " );
        chartSchedule.Legends.Clear();
        chartSchedule.Legends.Add("Legend1");
        agentSeries.ChartType = SeriesChartType.RangeColumn;
        agentSeries.Color = Color.Transparent;  // hide the default series entry!
        agentSeries["PixelPointWidth"] = "20"; // <- your choice of width!
        int index = 0;
        foreach (Agent a in _agents)
        {
            // Alternate colours 
            Color color = index % 2 == 0 ? Color.DodgerBlue : Color.Blue;
            // Display start and end columns of every task
            List<DataPoint> timeData = new List<DataPoint>();  ///???
            foreach (NodeTask t in a.AssignedTasks)
            {
                int p = agentSeries.Points.AddXY(index +1, t.StartTime, t.EndTime);
                agentSeries.Points[p].Color = color;
            }
            agentSeries.Legends[0].CustomItems.Add(color, "Agent " + index);
            index++;
        }
