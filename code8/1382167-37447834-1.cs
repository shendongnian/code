            this.InitializeComponent();
            //Setup plot1
            var plot1_model = new PlotModel { Title = "plot1 Score" };
            plot1_model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Minimum = 0, Maximum = a_count, Title = "Frame" });
            plot1_model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Minimum = 0, Maximum = 15, Title = "Score" });
            var plot1_Series = new LineSeries { StrokeThickness = 1, MarkerSize = 1 };
            for (int i = 0; i < a_count; i++)
            {
                int x_val = i;
                int y_val = your_data[0, i];
                plot1_Series.Points.Add(new DataPoint(x_val, y_val));
            }
            plot1_model.Series.Add(plot1_Series);
            //Setup plot2
            var plot2_Model = new PlotModel { Title = "plot2 Score" };
            plot2_Model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Minimum = 0, Maximum = a_count, Title = "Frame" });
            plot2_Model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Minimum = 0, Maximum = 15, Title = "Score" });
            var plot2_Series = new LineSeries { StrokeThickness = 1, MarkerSize = 1 };
            for (int i = 0; i < a_count; i++)
            {
                int x_val = i;
                int y_val = your_data[1, i];
                plot2_Series.Points.Add(new DataPoint(x_val, y_val));
            }
            plot2_Model.Series.Add(plot2_Series);
            //Setup plot3
            var plot3_Model = new PlotModel { Title = "plot3 Score" };
            plot3_Model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Minimum = 0, Maximum = a_count, Title = "Frame" });
            plot3_Model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Minimum = 0, Maximum = 15, Title = "Score" });
            var plot3_Series = new LineSeries{ StrokeThickness = 1, MarkerSize = 1};
            for (int i = 0; i < a_count; i++)
            {
                int x_val = i;
                int y_val = your_data[3, i];
                plot3_Series.Points.Add(new DataPoint(x_val, y_val));
            }
            this.plot1.Model = plot1_Model;
            this.plot2.Model = plot2_model;
            this.plot3.Model = plot3_Model;
