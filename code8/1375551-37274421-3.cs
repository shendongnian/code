        for (int i = 0; i < xs.Count; i++)
        {
            CustomLabel cl = new CustomLabel();
            cl.FromPosition = Math.Log10(xs[i]) * spacer;
            cl.ToPosition = Math.Log10(xs[i]) / spacer ;
            if (xs[i] <= 1)
            {
                cl.FromPosition = 0f;
                cl.ToPosition = 0.01f;
            }
            cl.Text = xs[i] + "";
            ca.AxisX.CustomLabels.Add(cl);
        }
