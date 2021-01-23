        // set up from clean slate:
        chart1.ChartAreas.Clear();
        chart1.Series.Clear();
        ChartArea CA = chart1.ChartAreas.Add("CA");
        Series S1 = chart1.Series.Add("S1");
        S1.ChartType = SeriesChartType.Column;  // whatever..
        // a few restriction for my own files:
        CA.AxisX.Maximum = new DateTime(2014, 12, 31).ToOADate();
        DirectoryInfo dInfo = new DirectoryInfo("D:\\");
        FileInfo[] Files = dInfo.GetFiles("f*.png");
        // staying with the file info list!
        //List<string> fileNames = new List<string>();
        //List<DateTime> fileDates = new List<DateTime>();
        chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
        chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
        chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Solid;
        chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
        chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
        chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
        chart1.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
        S1.IsValueShownAsLabel = true;
        S1.LabelFormat = "YYY.MM";
        // restrict to 20 files max:
        for (int i = 0; i < Math.Min(20, Files.Length); i++)
        {
            FileInfo FI = Files[i];
            int p = chart1.Series[0].Points.AddXY(FI.CreationTime, 1);
            S1.Points[p].Label = Path.GetFileNameWithoutExtension(FI.FullName);
        }
