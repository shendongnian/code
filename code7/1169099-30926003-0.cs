        public static PlotModel ExampleScatterSeriesPlot()
        {
            var plotModel1 = new PlotModel();
            plotModel1.Subtitle = "The scatter points are added to the Points collection.";
            plotModel1.Title = "ScatterSeries (n=1000)";
            var linearAxis1 = new LinearAxis();
            linearAxis1.Position = AxisPosition.Bottom;
            plotModel1.Axes.Add(linearAxis1);
            var linearAxis2 = new LinearAxis();
            plotModel1.Axes.Add(linearAxis2);
            var scatterSeries1 = new ScatterSeries();
            scatterSeries1.Points.Add(new ScatterPoint(0.667469348137951, 0.701595088793707));
            scatterSeries1.Points.Add(new ScatterPoint(7.74765135149828, 5.11139268759237));
            scatterSeries1.Points.Add(new ScatterPoint(7.97490558492714, 8.27308291023275));
            scatterSeries1.Points.Add(new ScatterPoint(1.65958795308116, 7.36130623489679));
            scatterSeries1.Points.Add(new ScatterPoint(2.6021636475819, 5.06004851081411));
            scatterSeries1.Points.Add(new ScatterPoint(2.30273722312541, 3.87140443263175));
            scatterSeries1.Points.Add(new ScatterPoint(2.15980615101746, 0.208108848989061));
            scatterSeries1.ActualPoints.Add(new ScatterPoint(0.667469348137951, 0.701595088793707));
            scatterSeries1.ActualPoints.Add(new ScatterPoint(7.74765135149828, 5.11139268759237));
            scatterSeries1.ActualPoints.Add(new ScatterPoint(7.97490558492714, 8.27308291023275));
            scatterSeries1.ActualPoints.Add(new ScatterPoint(1.65958795308116, 7.36130623489679));
            scatterSeries1.ActualPoints.Add(new ScatterPoint(2.6021636475819, 5.06004851081411));
            scatterSeries1.ActualPoints.Add(new ScatterPoint(2.30273722312541, 3.87140443263175));
            scatterSeries1.ActualPoints.Add(new ScatterPoint(2.15980615101746, 0.208108848989061));
            plotModel1.Series.Add(scatterSeries1);
            return plotModel1;
        }
