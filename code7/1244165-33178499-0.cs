    private enum State
    {
        Pan,
        Crop
    }
    private State _currentState;
    
    public void btnCrop_Click()
    {
        _currentState = State.Crop;
    }
    public void btnPan_Click()
    {
        _currentState = State.Pan;
    }
    
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        if (_currentState == State.Crop)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left )
            {
                Cursor = Cursors.Cross;
                cropX = e.X;
                cropY = e.Y;
                cropPen = new Pen(Color.FromArgb(153, 180, 209), 3);
                cropPen.DashStyle = DashStyle.DashDotDot;
                pictureBox1.Refresh();
            }
        }
        else // state = pan
        {            
            _isPanning = true;
            startPt = e.Location;
        }
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (_currentState == State.Crop)
        {
            Cursor = Cursors.Cross;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //X and Y are the position of the crop
                pictureBox1.Refresh();
                cropWidth = e.X - cropX;
                cropHeight = e.Y - cropY;
                pictureBox1.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
            }
        }
        else // state = pan
            if (_isPanning)
            {    
                Cursor = Cursors.SizeAll;
                Control c = (Control)sender;
                c.Left = (c.Left + e.X) - startPt.X;
                c.Top = (c.Top + e.Y) - startPt.Y;
                c.BringToFront();
            }
        }
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        Cursor = Cursors.Default;
        if (_currentState == State.Crop)
        {            
            if (cropWidth < 1)
            {
                return;
            }
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            //First we define a rectangle with the help of already calculated points
            Bitmap OriginalImage = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
            //Original image
            Bitmap _img = new Bitmap(cropWidth, cropHeight);
            // for cropinf image
            Graphics g = Graphics.FromImage(_img);
            // create graphics
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //set image attributes
            g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);
            pictureBox1.Image = _img;
            pictureBox1.Width = _img.Width;
            pictureBox1.Height = _img.Height;
        }
        else // state = pan
        {
            // nothing to do here but leaving it for symmetry with the other methods
        }        
    }
    
