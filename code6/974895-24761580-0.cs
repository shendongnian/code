    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        using (Bitmap bmp = new Bitmap(filename))
        {
            e.Graphics.ScaleTransform(zoom, zoom);
            e.Graphics.DrawImage(bmp, trb_offsetX.Value, trb_offsetY.Value);
        }
    }
    float zoom = 1f;
    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
       Point mouseLocation = e.Location;
       Point imageLocation = new Point( (int) ((mouseLocation.X / zoom - trb_offsetX.Value)  ),
                                        (int) ((mouseLocation.Y / zoom - trb_offsetY.Value) ) );
       st_mousePos.Text = "   "  +  imageLocation.ToString();
    }
    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        zoom = trackBar1.Value;
        panel1.Invalidate();
    }
