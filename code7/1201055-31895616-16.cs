        chart1.Series.Clear();
        Series S1 = chart1.Series.Add("S1");
        S1.ChartType = SeriesChartType.Column;
        ChartArea CA = chart1.ChartAreas[0];
        chart1.Legends.Clear();
        CA.BackColor = Color.AliceBlue;
        chart1.BackColor = Color.AliceBlue;
        Font f = new Font("Consolas", 9f);
        CA.AxisX.LabelStyle.Font = f;
        S1.BackGradientStyle = GradientStyle.LeftRight;
        CA.AxisX.MajorGrid.Enabled = false;
        CA.AxisX.MajorTickMark.Enabled = false;
        CA.AxisX.LineColor = Color.Transparent;
        CA.AxisY.Enabled = AxisEnabled.False;
        CA.AxisY.MajorGrid.Enabled = false;
        CA.AxisY.MajorTickMark.Enabled = false;
        CA.Position.X = 0f;
        List<Tuple<string, double>> data = new List<Tuple<string, double>>()
        {
            new Tuple<string, double>( "0-1 months", 4 ),
            new Tuple<string, double>( "2-3 months", 14 ),
            new Tuple<string, double>( "4-11 months", 44 ),
            new Tuple<string, double>( "1-2 years", 23 ),
            new Tuple<string, double>( "3-5 years", 3 ),
            new Tuple<string, double>( "> 5 years", 100 ),
        };
        double total = data.Sum(x => x.Item2);
        foreach (Tuple<string, double> t in data)
        {
            string label1 = string.Format("{0}\n{1:0.0}%", t.Item1, t.Item2 * 100d / total);
            string label2 = string.Format("\n\n{0:##0.0}GB", t.Item2);
            int i = S1.Points.AddXY(S1.Points.Count, t.Item2);
            S1.Points[i].Font = f;
            DataPoint dp = S1.Points[i];
            int v = (int)dp.YValues[0];
            CustomLabel cl = new CustomLabel();
            cl.Text = label1;
            cl.FromPosition = i - 0.5f;
            cl.ToPosition = i + 0.5f;
                
            CustomLabel cl2 = new CustomLabel();
            cl2.Text = label2;
            cl2.FromPosition = i -0.5f;
            cl2.ToPosition = i + 0.5f;
            cl2.ForeColor = Color.Green;
            CA.AxisX.CustomLabels.Add(cl);
            CA.AxisX.CustomLabels.Add(cl2);
        }
        S1.Points[0].Color = Color.YellowGreen;
        S1.Points[1].Color = Color.YellowGreen;
