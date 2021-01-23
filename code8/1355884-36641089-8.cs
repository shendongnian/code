    private void chart1_MouseClick(object sender, MouseEventArgs e)
    {
        HitTestResult hit = chart1.HitTest(e.X, e.Y);
        Series s = null;
        if (hit != null) s = hit.Series;
        if (s != null) 
        {
           string text = s.LegendText != "" ?  s.LegendText : s.Name;
           Console.WriteLine("Series # " + chart1.Series.IndexOf(s) + " ->  " + text);
        }
    }
