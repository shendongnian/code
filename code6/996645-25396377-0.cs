    Point p1 = new Point(0,0);
    private void pictureBox_MouseDown(object sender, MouseEventArgs e)
    {
        p1 = e.Location;
    }
    
    Rectangle rect = Rectangle.Empty;
    
    private void pictureBox_MouseUp(object sender, MouseEventArgs e)
    {
        rect = new Rectangle();
        //Left and Width
        if (e.Location.X > p1.X)
        {
            rect.X = p1.X;
            rect.Width = e.Location.X - p1.X;
        }
        else
        {
            rect.X = e.Location.X;
            rect.Width = p1.X - e.Location.X;
        }
    
        //Top and Height
        if (e.Location.Y > p1.Y)
        {
            rect.Y = p1.Y;
            rect.Height = e.Location.Y - p1.Y;
        }
        else
        {
            rect.Y = e.Location.Y;
            rect.Height = p1.Y - e.Location.Y;
        }
        if (rect.Width > 10 && rect.Height > 10)
           pictureBox.Invalidate();
    }
    
    private void pictureBox_Paint(object sender, PaintEventArgs e)
    {
        if (rect.Width > 10 && rect.Height > 10)
            e.Graphics.DrawRectangle(Pens.Gray, rect);
    }
    
    private Bitmap CropImage()
    {
        Bitmap pic = pictureBox.Image as Bitmap;
        Bitmap cropped = new Bitmap(rect.Width, rect.Height);
    
        using(Graphics g = Graphics.FromImage(cropped))
        {
           g.DrawImage(pic, new Rectangle(0, 0, rect.Width, rect.Height), 
                        rect,GraphicsUnit.Pixel);
        }
        return cropped
    
    }
