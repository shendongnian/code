    private void chart1_MouseClick(object sender, MouseEventArgs e)
    {
        //check where you clicked, returns different information like the clicked series name and the index of the clicked point
        HitTestResult clicked = chart1.HitTest(e.X, e.Y);
        //this is how you get your y-Value
        double yValue = chart1.Series[clicked.Series.Name].Points[clicked.PointIndex].YValues[0];
    }
