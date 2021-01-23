    List<Label> myLabels = new List<Label>();
    Label movingLabel = null;
    Point mDown = Point.Empty;
    private void button11_Click(object sender, EventArgs e)
    {
        Random R = new Random(8);
        Size sz = pictureBox1.ClientSize;
        for (int i = 0; i < 20; i++)
        {
            Label lbl = new Label() {Text = "L " + i};
            lbl.Location = new Point(R.Next(sz.Width), R.Next(sz.Height));
            lbl.Parent = pictureBox1;
            myLabels.Add(lbl);
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.MouseDown += (ss, ee) =>
                {
                    movingLabel = lbl;
                    lbl.BackColor = Color.Bisque;
                    mDown = ee.Location;  
                };
            lbl.MouseMove += (ss, ee) =>
                {
                    if (ee.Button == MouseButtons.Left)
                    {
                       Point nLoc = Point.Subtract(lbl.Location, 
                                          new Size(mDown.X - ee.X, mDown.Y - ee.Y));
                       Rectangle rlbNew = new Rectangle(nLoc, lbl.Size);
                       var overlapped = myLabels.Where(x => x != lbl && 
                                  rlbNew.IntersectsWith(new Rectangle(x.Location, x.Size)));
                       if (overlapped.Count() == 0) lbl.Location = nLoc;
                    }
                };
            lbl.MouseUp += (ss, ee) =>
                {
                    movingLabel = null;
                    lbl.BackColor = Color.Transparent;
                };
        }
    }
