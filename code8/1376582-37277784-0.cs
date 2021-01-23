    AxisY =
    new Axis
        {
            MajorGrid =
                new Grid
                    {
                        Enabled = true,
                        LineColor = Color.Black,
                        LineDashStyle = ChartDashStyle.Solid,
                        Interval = 50,
                        IntervalOffset = 0
                    },
            Title = yAxisDesc,
            Minimum = yAxisRange.Item1,
            Maximum = yAxisRange.Item2,
            LabelStyle = new LabelStyle{Interval = 50, Enabled=true,IntervalOffset = 0,IsEndLabelVisible = true},
            MajorTickMark =
                new TickMark
                    {
                        Enabled = true,
                        Interval = 50,
                        IntervalOffset = 0,
                    },
        }
