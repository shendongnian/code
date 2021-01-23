    var tmpPoints = new List<double>();
    for (var i = 0; i < points.Length;)
    {
        var value = points[i];
        var next = i + 1;
        if (next < points.Length && points[next] - points[i] < .5)
        {
            value = (points[i] + points[next]) / 2;
            i = next + 1;
        }
        else
        {
            i++;
        }
        tmpPoints.Add(value);
    }
    points = tmpPoints.ToArray();
    // Results using the two example sequences
    points = new[] { 2.1, 2.2, 2.6, 4, 4.2, 4.7, 4.8 };
    
    Result: 2.15, 2.6, 4.1, 4.75
    points = new[] { 8.8, 9.0 };
    Result: 8.9
      
