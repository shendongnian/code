    void addCustomLabels(ChartArea ca, Series series, int interval)
    {
        // we get the maximum form the 1st y-value
        int max = (int)series.Points.Select(x => x.YValues[0]).Max();
        // we delete any CLs we have
        ca.AxisY.CustomLabels.Clear();
        // now we add new custom labels
        for (int i = 0; i < max; i += interval)
        {
            CustomLabel cl = new CustomLabel();
            cl.FromPosition = i - interval / 2;
            cl.ToPosition = i + interval / 2;
            cl.Text = hhh_mm_ss(i);
            ca.AxisY.CustomLabels.Add(cl);
        }
    }
