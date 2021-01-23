    for (int i = 0; i < points.Length; i++)
    {
        var p = points[i];
        var intp = (double)((int)points[i]);
        if (p - intp < .5)
        {
            if (!groups.ContainsKey(intp))
            {
                groups[intp] = new List<double>();
            }
            groups[intp].Add(p);
        }
        else
        {
            groups[p] = new List<double> { p };
        }
    }
