    var model = new PlotModel { Title = "Test Mouse Events" };
    
    var s1 = new LineSeries();
    model.Series.Add(s1);
    int x;
    s1.MouseDown += (s, e) =>
                {
                    x = e.HitTestResult.NearestHitPoint.X;
                };
