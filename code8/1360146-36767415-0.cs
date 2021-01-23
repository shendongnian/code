    private void chartInForm_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        foreach(ChartArea ca in chartInForm.ChartAreas)
        {
            if (ChartAreaClientRectangle(chartInForm, ca).Contains(e.Location))
               Console.WriteLine(" You have double-clicked on chartarea " +  ca.Name;
        }
    }
    RectangleF ChartAreaClientRectangle(Chart chart, ChartArea CA)
    {
        RectangleF CAR = CA.Position.ToRectangleF();
        float pw = chart.ClientSize.Width / 100f;
        float ph = chart.ClientSize.Height / 100f;
        return new RectangleF(pw * CAR.X, ph * CAR.Y, pw * CAR.Width, ph * CAR.Height);
    }
