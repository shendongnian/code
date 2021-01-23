    private void button4_Click(object sender, EventArgs e)
    {
        ChartArea CA = chart1.ChartAreas[0];
        CA.AxisY.IsLogarithmic = true;
        List<double> fr = new List<double> {4,8,16,32,64};
        for (int i = 0; i < fr.Count; i++ )
        {
            CustomLabel cl = new CustomLabel();
            cl.FromPosition = i <= 0 ? 0 : fr[i - 1];
            cl.ToPosition = fr[i];
            cl.Text = fr[i] + " Hz";
            CA.AxisY.CustomLabels.Add(cl);
        }
        for (int i = 1; i < 50; i++)
        {
            chart1.Series[0].Points.AddXY(i, Math.Pow(2, i ) );
            chart1.Series[1].Points.AddXY(i, i * i);
        }
    }
