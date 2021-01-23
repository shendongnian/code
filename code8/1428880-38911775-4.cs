    var categoryAxis = new CategoryAxis()
    {
        Position = AxisPosition.Bottom,
        ...
    };
    categoryAxis.ActualLabels.Add("Mon");
    categoryAxis.ActualLabels.Add("Tue");
    categoryAxis.ActualLabels.Add("Wed");
    categoryAxis.ActualLabels.Add("Thu");
    categoryAxis.ActualLabels.Add("Fri");
    categoryAxis.ActualLabels.Add("Sat");
    categoryAxis.ActualLabels.Add("Sun");
    Model.Axes.Add(categoryAxis);
