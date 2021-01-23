    protected void Page_Load(object sender, EventArgs e)
    {
    double[] X = new double[]{10,15,20,25,30};
    double[] Y = new double[]{100,150,200,250,300};
    using (Bitmap xPanel = new Bitmap(500, 500))
    {
        using (Graphics objGraphicPanel = Graphics.FromImage(xPanel))
        {
            for (int nn = 1; nn < X.Length; nn++)
            {
                float x1 = Convert.ToSingle(X[nn - 1]);
                float y1 = Convert.ToSingle(Y[nn - 1]);
                float x2 = Convert.ToSingle(X[nn]);
                float y2 = Convert.ToSingle(Y[nn]);
                objGraphicPanel.DrawLine(colorPen, x1, y1, x2, y2);
            }
        }
        xPanel.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    }
