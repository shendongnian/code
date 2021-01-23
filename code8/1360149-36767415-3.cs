    private void chartInForm_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        foreach(ChartArea ca in chartInForm.ChartAreas)
        {
            if (ChartAreaClientRectangle(chartInForm, ca).Contains(e.Location))
               Console.WriteLine(" You have double-clicked on chartarea " +  ca.Name;
        }
    }
