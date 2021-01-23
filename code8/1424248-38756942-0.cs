    Image image = Image.FromFile(@"C:\Screenshots\Screenshot.jpeg");
    using (Graphics g = Graphics.FromImage(image))
    {
        SolidBrush brush = new SolidBrush(Color.Black);
        Size size = new Size(image.Width, 64);
        Point point = new Point(0, 0);
        Rectangle rectangle;
        rectangle = new Rectangle(point, size);
        g.FillRectangle(brush, rectangle);
    }
    image.Save(@"C:\Screenshots\Screenshot.jpeg");
