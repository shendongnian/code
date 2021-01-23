        protected void Page_Load(object sender, EventArgs e)
        {
            Chart1.ChartAreas[0].Position.Auto = false;
            Chart1.ChartAreas[0].Position.X = 0;
            Chart1.ChartAreas[0].Position.Y = 0;
            Chart1.ChartAreas[0].Position.Height = 25;
            Chart1.ChartAreas[0].Position.Width = 25;
            Chart1.ChartAreas[1].Position.Auto = false;
            Chart1.ChartAreas[1].Position.X = 25;
            Chart1.ChartAreas[1].Position.Y = 0;
            Chart1.ChartAreas[1].Position.Height = 25;
            Chart1.ChartAreas[1].Position.Width = 25;
        }
