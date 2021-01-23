            if (this.chart1.InvokeRequired)
            {
                BeginInvoke((Action)(() =>
                {
                    if (!chartState) return;
                    DateTime now = DateTime.Now;
                    chart1.ResetAutoValues();
                    for (int i = 0; i < chart1.Series.Count; i++)
                    {
                        if (chart1.Series[i].Points.Count > 0)
                        {
                            while (chart1.Series[i].Points[0].XValue < now.AddMinutes(-60).ToOADate())
                            {
                                chart1.Series[i].Points.RemoveAt(0);
                                chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[i].Points[0].XValue;
                                chart1.ChartAreas[0].AxisX.Maximum = now.AddMinutes(1).ToOADate();
                            }
                        }
                    }
                    chart1.Series["Sebeke"].Points.AddXY(now.ToOADate(), AnlikSebeke);
                    chart1.Series["Turbin"].Points.AddXY(now.ToOADate(), AnlikTurbin);
                    chart1.Series["Tuketim"].Points.AddXY(now.ToOADate(), AnlikTuketim);
                    chart1.Invalidate();
                }));
            }
