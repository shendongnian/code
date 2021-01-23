    public Bitmap AppendImageFooter(System.Drawing.Image bmp, string text)
    {
        //Create new image that will be bigger then original image to make place for footer
        Bitmap newImage = new Bitmap(bmp.Height+200,bmp.Width);
        //Get graphics and copy image and below the footer
        Graphics g = Graphics.FromImage(bmp);
        g.DrawImage(bmp, new Point(0, 0));
        g.FillRectangle(new SolidBrush(Color.Black), 0, bmp.Height, bmp.Width, 200);
        g.DrawString(text, new Font("Arial", 14), new SolidBrush(Color.White), 20, bmp.Height + 20);
        //Anything else you like, circles, rectangles, texts etc..
        g.Dispose();
        return newImage;
    }
