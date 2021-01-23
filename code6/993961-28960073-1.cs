        //your function based on x,y
        public double getValue(int x, int y)
        {
            return (10 * x * x + 11 * x*y*y  + 12*x*y );
        }
        //setting the values to the function
        public FunctionSeries GetFunction()
        { 
            int n = 100;
            FunctionSeries serie = new FunctionSeries();
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    //adding the points based x,y
                    DataPoint data = new DataPoint(x, getValue(x,y));
                    //adding the point to the serie
                    serie.Points.Add(data);
                }
            }
            //returning the serie
            return serie;
        }
        //setting all the parameters of the model
        public void graph()
        {
            model = new PlotModel { Title = "example" };
            model.LegendPosition = LegendPosition.RightBottom;
            model.LegendPlacement = LegendPlacement.Outside;
            model.LegendOrientation = LegendOrientation.Horizontal;
            model.Series.Add(GetFunction());
            var Yaxis = new OxyPlot.Axes.LinearAxis();
            OxyPlot.Axes.LinearAxis XAxis = new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom, Minimum = 0, Maximum = 100 };
            XAxis.Title = "X";
            Yaxis.Title = "10 * x * x + 11 * x*y*y  + 12*x*y";
            model.Axes.Add(Yaxis);
            model.Axes.Add(XAxis);
            this.plot.Model = model;
        }
        //on click on the button 3 then show the graph
        private void button3_Click(object sender, EventArgs e)
        {
            graph();
        }
