    void addSumSeries(Chart chart, Series s)
    {
        ChartArea CA = chart1.ChartAreas[0];       // short name
        CA.AxisY2.Enabled = AxisEnabled.True;      // turn on secondary y-axis
        CA.AxisY2.MajorGrid.Enabled = false;       // no grid lines
        CA.AxisY2.MinorTickMark.Enabled = true;    // show tick marks
        CA.AxisY2.Maximum = CA.AxisY.Maximum;      // synch display scale
        // find the maximum value; we'll show all values from 0 to sMax
        int sMax = (int) s.Points.Select(x => x.YValues[0]).Max<double>();  
        double[] sums = new double[sMax + 1];
        for (int i = 0; i < s.Points.Count; i++ )      // loop over data
        {
            int val = (int) s.Points[i].YValues[0];    // get value
            sums[val] += 1;                            // count values
        }
        // now create custom labels: each shows the count..
        // ..and is placed in the middle between the last and the next value
        for (int i = 0; i < sums.Length; i++)
        {
            CustomLabel cl = new CustomLabel();
            cl.Text = sums[i].ToString("###0"); // to get that right you'd need special spaces
            cl.FromPosition = i - 0.5;
            cl.ToPosition = i + 0.5;
            CA.AxisY2.CustomLabels.Add(cl);
        }
    }
