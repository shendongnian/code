    Measurements = new Collection<Measurement>();
    int N = 500;
    Subtitle = "N = " + N;
    
    var r = new Random(385);
    double dy = 0;
    double y = 0;
    for (int i = 0; i < N; i++)
    {
        dy += r.NextDouble() * 2 - 1;
        y += dy;
    
        // Create a line break
        if (i % 10 == 0)
        {
            Measurements.Add(new Measurement
            {
                Time = double.NaN,
                Value = double.NaN
            });   
        }
        else
        {
            Measurements.Add(new Measurement
            {
                Time = 2.5 * i / (N - 1),
                Value = y / (N - 1),
            });   
        }
    }
