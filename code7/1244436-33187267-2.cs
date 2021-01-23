    private void button4_Click(object sender, EventArgs e)
    {
        Series S2 = chart1.Series.Add("Series2");
        ChartArea CA = chart1.ChartAreas[0];
        CA.AxisY.IsLogarithmic = true;
        List<double> fr = new List<double>();
        for (int i = 3; i < 18; i++ )
        {
            fr.Add(Math.Pow(2, 1f * i / 2));
        }
            for (int i = 1; i < fr.Count; i+=2)
            {
                CustomLabel cl = new CustomLabel();
                cl.FromPosition =  fr[i - 1];
                cl.ToPosition = fr[i + 1];
                cl.Text = fr[i] + " Hz";
                CA.AxisY.CustomLabels.Add(cl);
            }
        for (int i = 1; i < 60; i++)
        {
            chart1.Series[0].Points.AddXY(i, Math.Pow(2, i));
            chart1.Series[1].Points.AddXY(i, i * i);
        }
    }
