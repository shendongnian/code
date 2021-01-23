    private void Form1_Load(object sender, EventArgs e)
    {
    	chart1.Series.Clear();
    
    	chart1.ChartAreas[0].Position = new ElementPosition(0, 0, 100, 100);
    
    	Series s1 = new Series();
    	s1.ChartType = SeriesChartType.RangeBar;
    	s1.Points.AddXY(2, 2);
    	s1.Points.AddXY(1, 1);
    
    	chart1.Series.Add(s1);
    
    	ChartArea ca2 = new ChartArea();
    	chart1.ChartAreas.Add(ca2);
    	ca2.Position = new ElementPosition(0, 0, 100, 100);
    	ca2.BackColor = Color.Transparent;
    
    	Series s2 = new Series();
    	s2.ChartType = SeriesChartType.Point;
    	s2.MarkerStyle = MarkerStyle.Triangle;
    	s2.MarkerSize = 10;
    	s2.Points.AddXY(2, 2);
    	s2.ChartArea = ca2.Name;
    
    	chart1.Series.Add(s2);
    }
