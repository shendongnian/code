            // Make a new plotmodel
        private PlotModel model = new PlotModel();
        // Create the OxyPlot graph for Salt Split
        private OxyPlot.Wpf.PlotView plot = new OxyPlot.Wpf.PlotView();
        // Function to plot data
        private void plotData(double numWeeks, double startingSS)
        {
            List<LineSeries> listPointAray = new List<LineSeries>();
            // Initialize new Salt Split class for acess to data variables
            Salt_Split_Builder calcSS = new Salt_Split_Builder();
            calcSS.compute(numWeeks, startingSS, maxDegSS);
            // Create new Line Series
            LineSeries linePoints = new LineSeries() 
            { StrokeThickness = 1, MarkerSize = 1, Title = numWeeks.ToString() + " weeks" };
            // Add each point to the new series
            foreach (var point in calcSS.saltSplitCurve)
            {
                DataPoint XYpoint = new DataPoint();
                XYpoint = new DataPoint(point.Key, point.Value * 100);
                linePoints.Format("%", XYpoint.Y);
                linePoints.Points.Add(XYpoint);
            }
            listPointAray.Add(linePoints);
            // Add Chart Title
            model.Title = "Salt Split Degradation";
            // Add Each series to the
            foreach (var series in listPointAray)
            {
                // Define X-Axis
                OxyPlot.Axes.LinearAxis Xaxis = new OxyPlot.Axes.LinearAxis();
                Xaxis.Maximum = numWeeks;
                Xaxis.Minimum = 0;
                Xaxis.Position = OxyPlot.Axes.AxisPosition.Bottom;
                Xaxis.Title = "Number of Weeks";
                model.Axes.Add(Xaxis);
                //Define Y-Axis
                OxyPlot.Axes.LinearAxis Yaxis = new OxyPlot.Axes.LinearAxis();
                Yaxis.MajorStep = 15;
                Yaxis.Maximum = calcSS.saltSplitCurve.Last().Value * 100;
                Yaxis.MaximumPadding = 0;
                Yaxis.Minimum = 0;
                Yaxis.MinimumPadding = 0;
                Yaxis.MinorStep = 5;
                Yaxis.Title = "Percent Degradation";
                //Yaxis.StringFormat = "{0.00} %";
                model.Axes.Add(Yaxis);
                model.Series.Add(series);
            }
            // Add the plot to the window
            
            plot.Model = model;
            plot.InvalidatePlot(true);
            SaltSplitChartGrid.Children.Clear();
            SaltSplitChartGrid.Children.Add(plot);
            
        }
