    private bool[] isCropped;
    private Image img;
    private Image imgClone;
    public Form1()
        {
            InitializeComponent();
            img = new Bitmap(pictureBoxSnap.Width, pictureBoxSnap.Height);
            imgClone = new Bitmap(pictureBoxSnap.Width, pictureBoxSnap.Height);
            Graphics g;
            using (g = Graphics.FromImage(img))
            {
                g.Clear(Color.White);
            }
            pictureBoxSnap.Image = img;
            ...
            ...
            rectangles = new Rectangle[listBoxSnap.Items.Count];
            isCropped = new bool[listBoxSnap.Items.Count];
            ...
        }
    private void listBoxSnap_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawpicbox(this.listBoxSnap.SelectedIndex);
        }
    private void drawpicbox(int index)
        {
            Graphics g, g1;
            Size sz;
            WindowSnap snap = this.listBoxSnap.SelectedItem as WindowSnap;
            Bitmap testBmp;
            using (g = Graphics.FromImage(img))
            {
                g.Clear(Color.White);
                sz = calculateSizeAndPosition(snap.Image.Size);
                if (isCropped[index] == true)
                {
                    ConfirmRectangle.Enabled = false;
                    using (testBmp = new Bitmap (img.Width , img.Height )){
                        using (g1 = Graphics.FromImage(testBmp))
                        {
                            g1.Clear(Color.White);
                            g1.DrawImage(snap.Image, (int)((pictureBoxSnap.Width - sz.Width) / 2.0), (int)((pictureBoxSnap.Height - sz.Height) / 2.0), sz.Width, sz.Height);
                        }
                        g.DrawImage(testBmp, rectangles[index], rectangles[index], GraphicsUnit.Pixel);
                        g.DrawRectangle(Pens.Firebrick, rectangles[index]);
                    }
                }
                else if (rectangles[index].Width != 0)
                {
                    ConfirmRectangle.Enabled = true;
                    g.DrawImage(snap.Image, (int)((pictureBoxSnap.Width - sz.Width) / 2.0), (int)((pictureBoxSnap.Height - sz.Height) / 2.0), sz.Width, sz.Height);
                    g.DrawRectangle(Pens.Firebrick, rectangles[index]);
                }
                else
                {
                    ConfirmRectangle.Enabled = false;
                    g.DrawImage(snap.Image, (int)((pictureBoxSnap.Width - sz.Width) / 2.0), (int)((pictureBoxSnap.Height - sz.Height) / 2.0), sz.Width, sz.Height);
                }
                
            }
            pictureBoxSnap.Invalidate();
        }
    private Size calculateSizeAndPosition(Size snapSize)
        {
            int wdth, hgt;
            Single  flt;
           
            wdth = snapSize.Width;
            hgt = snapSize.Height;
            flt = (Single)wdth / (Single)hgt;
            if (wdth <= pictureBoxSnap.Width && hgt <= pictureBoxSnap.Height)
            {
                //return new Size(wdth, hgt);
            }
            else{
                if(wdth >= hgt){
                    while (true)
                    {
                        wdth--;
                        hgt = (int)(wdth / flt);
                        if (wdth <= pictureBoxSnap.Width && hgt <= pictureBoxSnap.Height)
                        {
                            break;
                        }
                    }
                }
                else{
                    while (true)
                    {
                        hgt--;
                        wdth = (int)((Single)hgt * flt);
                        if (wdth <= pictureBoxSnap.Width && hgt <= pictureBoxSnap.Height)
                        {
                            break;
                        }
                    }
                }
            }
            return new Size(wdth, hgt);
        }
    private void pictureBoxSnap_MouseMove(object sender, MouseEventArgs e)
        {
            if (isCropped[listBoxSnap.SelectedIndex] == false && e.Button == MouseButtons.Left && e.Location != RectStartPoint)
            {
                DrawRectangle(e.Location);
            }
        }
    private void DrawRectangle(Point pnt)
        {
            Graphics g = Graphics.FromImage(img);
            
            //g.DrawRectangle(Pens.Firebrick, 50, 50, 300, 200);
            g.DrawImage(imgClone, 0, 0);
            if (pnt.X == RectStartPoint.X || pnt.Y == RectStartPoint.Y)
            {
                g.DrawLine(Pens.Firebrick, RectStartPoint.X, RectStartPoint.Y, pnt.X, pnt.Y);
            }
            else if (pnt.X > RectStartPoint.X && pnt.Y > RectStartPoint.Y) //Right-Down
            {
                rect.X = RectStartPoint.X; rect.Y = RectStartPoint.Y; rect.Width = pnt.X - RectStartPoint.X; rect.Height = pnt.Y - RectStartPoint.Y;
                g.DrawRectangle(Pens.Firebrick, rect);
            }
            else if (pnt.X > RectStartPoint.X && pnt.Y < RectStartPoint.Y) //Right-Up
            {
                rect.X = RectStartPoint.X; rect.Y = pnt.Y; rect.Width = pnt.X - RectStartPoint.X; rect.Height = RectStartPoint.Y - pnt.Y;
                g.DrawRectangle(Pens.Firebrick, rect);
            }
            else if (pnt.X < RectStartPoint.X && pnt.Y > RectStartPoint.Y) //Left-Down
            {
                rect.X = pnt.X; rect.Y = RectStartPoint.Y; rect.Width = RectStartPoint.X - pnt.X; rect.Height = pnt.Y - RectStartPoint.Y;
                g.DrawRectangle(Pens.Firebrick, rect);
            }
            else //Left-Up
            {
                rect.X = pnt.X; rect.Y = pnt.Y; rect.Width = RectStartPoint.X - pnt.X; rect.Height = RectStartPoint.Y - pnt.Y;
                g.DrawRectangle(Pens.Firebrick, rect);
            }
            g.Dispose();
            
            pictureBoxSnap.Invalidate();
        }
    private void pictureBoxSnap_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g;
            Size sz;
            if (isCropped[listBoxSnap.SelectedIndex] == false && e.Button == MouseButtons.Left)
            {
                WindowSnap snap = this.listBoxSnap.SelectedItem as WindowSnap;
                RectStartPoint = e.Location;
                
                sz = calculateSizeAndPosition(snap.Image.Size);
                using (g = Graphics.FromImage(imgClone))
                {
                    g.Clear(Color.White);
                    g.DrawImage(snap.Image, (int)((pictureBoxSnap.Width - sz.Width) / 2.0), (int)((pictureBoxSnap.Height - sz.Height) / 2.0), sz.Width, sz.Height);
                }
            }
        }
    private void pictureBoxSnap_MouseUp(object sender, MouseEventArgs e)
        {
            if (isCropped[listBoxSnap.SelectedIndex] == false && e.Button == MouseButtons.Left && e.Location.X != RectStartPoint.X && e.Location.Y != RectStartPoint.Y)
            {
                ConfirmRectangle.Enabled = true;
                rectangles[listBoxSnap.SelectedIndex] = rect;
                //drawpicbox(this.listBoxSnap.SelectedIndex);
            }
        }
    private void ConfirmRectangle_Click(object sender, EventArgs e)
        {
            isCropped[this.listBoxSnap.SelectedIndex] = true;
            drawpicbox(this.listBoxSnap.SelectedIndex);
        }
    private void Reset_Click(object sender, EventArgs e)
        {
            isCropped[this.listBoxSnap.SelectedIndex] = false;
            rectangles[this.listBoxSnap.SelectedIndex] = new Rectangle(0, 0, 0, 0);
            drawpicbox(this.listBoxSnap.SelectedIndex);
        }
    private void pictureBoxSnap_Paint(object sender, PaintEventArgs e)
        { 
            //Nothing
        }
