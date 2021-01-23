    protected void ImageMap1_Click(object sender, ImageClickEventArgs e){
        int x = int.Parse(e.X.ToString());
        int y = int.Parse(e.Y.ToString());
        Bitmap bitMapIm = new System.Drawing.Bitmap(Server.MapPath("~/carImage.jpg"));
        Graphics graphicIm = Graphics.FromImage(bitMapIm);
        Pen penRed = new Pen(Color.Red, 3);
        graphicIm.DrawString("X", new Font("Arial", 25, FontStyle.Bold), Brushes.Red, x, y);
        bitMapIm.Save(Server.MapPath("~/carImage1.jpg"), ImageFormat.Jpeg);
        graphicIm.Dispose();
        bitMapIm.Dispose();
        ImageMap1.ImageUrl = "~/carImage1.jpg";
    }
