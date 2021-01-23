    public partial class WebForm1 : System.Web.UI.Page
    {
        float deltax, deltay, deltay2;
        Graphics g;
        Font font;
        Brush brush;
        Random r;
        protected void Page_Load(object sender, EventArgs e)
        {
            deltax = 7.5F;
            deltay = 60;
            deltay2 = 5;
            font = new Font("Courier", 14);
            brush = new SolidBrush(Color.Red);
            r = new Random();
            for (int i = 1; i <= 5; i++)
                Chart1.Series[0].Points.Add(new DataPoint(i, new double[2] { r.Next(10, 40), r.Next(60, 90) }));
        }
        protected void Chart1_PostPaint(object sender, ChartPaintEventArgs e)
        {
            g = e.ChartGraphics.Graphics;
            RectangleF r = g.ClipBounds;
            if (e.ChartElement.ToString().Contains("Series"))
            {
                int count = Chart1.Series[0].Points.Count - 1;
                for (int i = count; i >= 0; i--)
                {
                    DataPoint dp = Chart1.Series[0].Points[i];
                    float size = (float)(deltax*(dp.YValues[1] - dp.YValues[0] + deltay2));
                    float x = (float)(deltax * dp.YValues[0]);
                    float y = (float)(deltay * (count - dp.XValue + 2));
                    e.ChartGraphics.Graphics.DrawString(string.Format("{0}", dp.YValues[0]), font, brush, new PointF(x, y));
                    e.ChartGraphics.Graphics.DrawString(string.Format("{0}", dp.YValues[1]), font, brush, new PointF(x + size, y));
                }
            }
        }
        protected void Chart1_PrePaint(object sender, ChartPaintEventArgs e)
        {
        }
        protected void Chart1_CustomizeMapAreas(object sender, CustomizeMapAreasEventArgs e)
        {
            foreach (MapArea m in e.MapAreaItems)
            {
            }
        }
        protected void Chart1_Customize(object sender, EventArgs e)
        {
           
        }
        protected void Chart1_CustomizeLegend(object sender, CustomizeLegendEventArgs e)
        {
            foreach (LegendItem li in e.LegendItems)
            {
            }
        }
    }
