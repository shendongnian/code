    List<KeyValuePair<string, int>> valueList1 = new List<KeyValuePair<string, int>>();
    valueList1.Insert(0, new KeyValuePair<string, int>(DateTime.Now.ToString(), 1));
    
    LineSeries lineSeries1 = new LineSeries();
    lineSeries1.Title = "Eins";
    lineSeries1.DependentValuePath = "Value";
    lineSeries1.IndependentValuePath = "Key";
    lineSeries1.ItemsSource = valueList1;
    ChartMain.Series.Add(lineSeries1);
    
    LinearAxis linearAxis = new LinearAxis();
    linearAxis.Orientation = AxisOrientation.Y;
    linearAxis.Minimum = 0;
    linearAxis.Maximum = +1;
    linearAxis.Interval = 0.1;
    
    ChartMain.Axes.Add(linearAxis);
