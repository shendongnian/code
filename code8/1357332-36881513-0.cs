        int viewcount=0,count=0,mviewcount=60;
        public void AddData() // executing using thread
        {
            while (true)
            {
                if (flag) // making flag as true by calling timer for every 1sec
                {
                    flag = false;
                    DateTime timeStamp = DateTime.Now;
                    double y1 = 0.0;
                    double y2= 0.0;
                    y1= gety1(count);
                    y2= gety2(count + 1);
                   
                    AddNewPoint(timeStamp, chart1.Series[0], chart1.Series[1], oilvalue, tempvalue);
                   
                    count++;
                }
                Thread.Sleep(1);
            }
        }
       public void AddNewPoint(DateTime timeStamp, System.Windows.Forms.DataVisualization.Charting.Series ptSeries1, System.Windows.Forms.DataVisualization.Charting.Series ptSeries2, double y1, double y2)
        {
            if (this.chart1.InvokeRequired)
            {
                BeginInvoke((Action)(() =>
                {                  
                    this.chart1.Series[0].Points.AddXY(timeStamp.ToOADate(), y1);
                    this.chart1.Series[1].Points.AddXY(timeStamp.ToOADate(), y2);
                    if ((count % 60) == 0)
                    {                
                        mviewcount += 60;
                        viewcount += 60;
                        chart1.ChartAreas[0].AxisX.Minimum = DateTime.FromOADate(ptSeries1.Points[count - 1].XValue).ToOADate(); 
                        chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(ptSeries1.Points[count - 1].XValue).AddMinutes(1).ToOADate();                        
                        min = chart1.ChartAreas[0].AxisX.Minimum;
                        max = chart1.ChartAreas[0].AxisX.Maximum;                       
                    }
                    if (count >= 60)
                    {
                        if ((count >= viewcount) || (count <= mviewcount))
                        {                        
                            chart1.Series[0].Points[0].AxisLabel = System.DateTime.FromOADate(chart1.Series[0].Points[count - 1].XValue).ToString();
                            chart1.ChartAreas[0].AxisX.ScaleView.Position = max;
                        }
                    }                    
                  
                    chart1.Update();
                    chart1.ChartAreas[0].RecalculateAxesScale();
                }));
            }
        }
  
