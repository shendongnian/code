     protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "image/jpeg";
            Response.Clear();
            Bitmap bitmap1 = new Bitmap(150, 150);
            Graphics g = Graphics.FromImage(bitmap1);
            g.Clear(Color.White);
            Point[] points = {
                new Point(75,0),
                new Point(150,150),
                new Point(0,50),
                new Point(150,50),
                new Point(0,150),
                new Point(75,0)
             };
            g.DrawLines(Pens.Black, points);
            bitmap1.Save(Response.OutputStream, ImageFormat.Jpeg);
            bitmap1.Dispose();
            g.Dispose();
            Response.Flush();
        }
