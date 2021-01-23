            private void chart1_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.X < 0 || e.Y < 0 || e.Location == prevPos)
                    return;
                prevPos = e.Location;
                if (this.graphShowingData == false)
                    return;
    
                Point p = new Point(e.X, e.Y);
                double searchVal = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
    
                foreach (DataPoint dp in chart1.Series["Series1"].Points)
                {
                    if(dp.XValue >= searchVal)
                    {
                        chart1.ChartAreas[0].CursorX.SetCursorPosition(dp.XValue);
                        foreach(double yD in dp.YValues)
                        {
                            val_series1.Text = Math.Round(yD, 4).ToString();
                        }
                        break;
                    }
                }
    
                foreach (DataPoint dp in chart1.Series["Series2"].Points)
                {
                    if (dp.XValue >= searchVal)
                    {
                        foreach (double yD in dp.YValues)
                        {
                            val_series2.Text = Math.Round(yD, 4).ToString();
                        }
                        break;
                    }
                }
    
    
                DateTime t = DateTime.FromOADate(chart1.ChartAreas[0].CursorX.Position);
                graph_time.Text = t.ToLongTimeString();
    
            }
