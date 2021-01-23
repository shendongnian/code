        // create some test data
        int numPoints = 30;
        List<int> normalData = new List<int>();
        List<int> negativeData = new List<int>();
        List<int> positiveData = new List<int>();
        List<int> dummyData = new List<int>();
        for (int i = 0; i < numPoints; i++)
        {
            positiveData.Add(R.Next(i + 22));
            normalData.Add(R.Next(i + 33));
            negativeData.Add(R.Next(i + 44));
        }
        // we need an offset:
        int max = negativeData.Max() + normalData.Max() / 2;
        // calculate the transparent bottom series:
        for (int i = 0; i < numPoints; i++)
        {
            dummyData.Add(max - normalData[i] / 2 - negativeData[i]);
        }
        // set up the Chart:
        chart1.ChartAreas.Add("Area 51");
        Series s0 = chart1.Series.Add(" ");
        Series s1 = chart1.Series.Add("negative");
        Series s2 = chart1.Series.Add("normal");
        Series s3 = chart1.Series.Add("positive");
        s0.ChartType = SeriesChartType.StackedArea;
        s1.ChartType = SeriesChartType.StackedArea;
        s2.ChartType = SeriesChartType.StackedArea;
        s3.ChartType = SeriesChartType.StackedArea;
        s0.Color = Color.Transparent;
        s1.Color = Color.Red;
        s2.Color = Color.Gray;
        s3.Color = Color.Green;
        // now add the data points:
        for (int i = 0; i < numPoints; i++)
        {
            s0.Points.AddXY(i, dummyData[i]);
            s1.Points.AddXY(i, negativeData[i] );
            s2.Points.AddXY(i, normalData[i]);
            s3.Points.AddXY(i, positiveData[i]);
        }
