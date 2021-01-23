        public void Main()
        {
            string[] chartNames = { "A1", "A2", "A3", "A4", "B1", "B2", "B3" };
            List<Chart> charts = new List<Chart>;
            int i = 0;
            foreach(string cname in chartNames)
            {
                i++;
                ChartArea chartArea = new ChartArea();
                Chart thisChart = new Chart();
                Series series1 = new Series();
                Series series2 = new Series();
                chartArea.Position.Auto = false;
                thisChart.ChartAreas.Add(chartArea);
                //each chart will be 43 units higher than the last
                thisChart.Location = new System.Drawing.Point(216, (43*i));
                series1.ChartType = SeriesChartType.StackedBar100; 
                series2.ChartType = SeriesChartType.StackedBar100;
                series1.Name = "Series1";
                series2.Name = "Series2";
                thisChart.Series.Add(series1);
                thisChart.Series.Add(series2);
                thisChart.Size = new System.Drawing.Size(100, 34);
                thisChart.TabStop = false;
                //sets the name of this chart to the corresponding string from the array of names
                thisChart.Name = cname;          
                thisChart.Click += new System.EventHandler(this.chartClick);
                //add this chart to the list of charts
                charts.Add(thisChart);
            }     
        }
        private void chartClick(Object sender, EventArgs e)
        {
            //you can differentiate between charts using the sender.name property
            Chart senderChart = (Chart)sender;
            if(senderChart.Name == "A1")
            {
                //if the chart with name A1 is clicked...
            }
        }
