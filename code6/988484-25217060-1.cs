    Chart1.Series.Add(series);
    
    Series series1 = Chart1.Series[0];
    series1.Points.DataBindXY(xValues, yValues);
    
    Title ti = new Title()
    ti.TextStyle = TextStyle.Emboss;
    ti.Text = ((yValues[0] / 100) * 100) + @"%%";//double Percentage sign 
    ti.Font = new Font("Times New Roman", 40, FontStyle.Bold);     
    ti.Position.X = 50;
    ti.Position.Y = 50;
    
    Chart1.Titles.Add(ti);
