        for (int i = 0; i < xs.Count; i++)
        {
            CustomLabel cl = new CustomLabel();
            if (xs[i] == 1 || xs[i] <= 0)
            {
                cl.FromPosition = 0f;
                cl.ToPosition = 0.01f;
            }
            else
            {
                cl.FromPosition = Math.Log10(xs[i] * spacer);
                cl.ToPosition = Math.Log10(xs[i] / spacer);
            }
            cl.Text = xs[i] + "";
            ca.AxisX.CustomLabels.Add(cl);
        }
