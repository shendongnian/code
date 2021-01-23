    for (double vx = ax.Minimum; vx < ax.Maximum; vx += ax.Interval)
        for (double vy = ay.Minimum; vy <= ay.Maximum; vy += ay.Interval)
            s0.Points.AddXY(vx, vy);
    s0.Points[333].MarkerColor = Color.Red;
    s0.Points[333].MarkerSize = 12;
