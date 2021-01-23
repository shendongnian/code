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
                _cropX = e.X;
                _cropY = e.Y;
                _cropPen = new Pen(Color.FromArgb(153, 180, 209), 3);
                _cropPen.DashStyle = DashStyle.DashDotDot;
                pictureBox1.Refresh();
            }
        }
        else // state = pan
        {            
            _isPanning = true;
            _startPt = e.Location;
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
                _cropWidth = e.X - _cropX;
                _cropHeight = e.Y - _cropY;
                pictureBox1.CreateGraphics().DrawRectangle(_cropPen, _cropX, _cropY, _cropWidth, _cropHeight);
            }
        }
        else // state = pan
            if (_isPanning)
            {    
                Cursor = Cursors.SizeAll;
                Control c = (Control)sender;
                c.Left = (c.Left + e.X) - _startPt.X;
                c.Top = (c.Top + e.Y) - _startPt.Y;
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
            Rectangle rect = new Rectangle(_cropX, _cropY, _cropWidth, _cropHeight);
            //First we define a rectangle with the help of already calculated points
            Bitmap originalImage = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
            //Original image
            Bitmap img = new Bitmap(_cropWidth, _cropHeight);
            // for cropinf image
            Graphics g = Graphics.FromImage(img);
            // create graphics
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //set image attributes
            g.DrawImage(originalImage, 0, 0, rect, GraphicsUnit.Pixel);
            pictureBox1.Image = img;
            pictureBox1.Width = img.Width;
            pictureBox1.Height = img.Height;
        }
        else // state = pan
        {
            // nothing to do here but leaving it for symmetry with the other methods
        }        
    }
    
