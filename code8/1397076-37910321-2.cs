        Graphics g;
        Pen p;
        Bitmap bmp;
        List<Point> Lines = new List<Point>();
        private void Form2_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BackgroundImage = bmp;
            g = Graphics.FromImage(BackgroundImage);
            g.Clear(Color.DeepSkyBlue); //This is our backcolor
        }
        private void btnLine1_Click(object sender, EventArgs e)
        {
            Point A = new Point(50, 50);
            Point B = new Point(100, 50);
            p = new Pen(Color.Red);
            g.DrawLine(p, A, B); //Use whatever method to draw your line
            Lines.Add(A); //Grab the first point; add to list
            Lines.Add(B); //Grab the second point; add to list
            Refresh(); //Refresh drawing to bitmap.
        }
        private void btnDrawLine2_Click(object sender, EventArgs e)
        {
            Point A = new Point(50, 60);
            Point B = new Point(100, 60);
            p = new Pen(Color.White);
            g.DrawLine(p, A, B); //Same logic as above
            Lines.Add(A);
            Lines.Add(B);
            Refresh();
        }
        private void btnUndo_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.DeepSkyBlue); //Pen with our backcolor
            try //Prevents null exception when no lines exist
            {
                g.DrawLine(p, Lines.ElementAt(Lines.Count - 2), Lines.ElementAt(Lines.Count - 1)); //Draw a line using points from the second last, and last items in our list
                Lines.RemoveAt(Lines.Count - 2);
                Lines.RemoveAt(Lines.Count - 1); //Remove those used points
            }
            catch { }
            Refresh();
        }
