    string[] seriesArray = { "Cat", "Dog", "Bird", "Monkey" };
    Series series = chart1.Series.Add("Animals");
    int[] pointsArray = { 2, 1, 7, 5 };
    for (int i = 0; i < seriesArray.Length; i++)
    {
        DataPoint point = series.Points.Add(pointsArray[i]);
        point.AxisLabel = seriesArray[i];
    }
