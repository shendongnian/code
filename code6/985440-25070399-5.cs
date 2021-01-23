    string theText ="123 - The quick brown fox..";
    Label L1, L2, L3;
    pictureBox1.Controls.Add(new trLabel());
    L1 = (trLabel)pictureBox1.Controls[pictureBox1.Controls.Count - 1];
    L1.Text = theText;
    L1.ForeColor = Color.FromArgb(150, 0, 0, 0);
    L1.Location = new Point(231, 31);  // <- position in the image, change!
    L1.Controls.Add(new trLabel());
    L2 = (trLabel)L1.Controls[pictureBox1.Controls.Count - 1];
    L2.Text = theText;
    L2.ForeColor = Color.FromArgb(150, 0, 0, 0);
    L2.Location = new Point(2, 2);  // do not change relative postion in the 1st label!
    L2.Controls.Add(new trLabel());
    L3 = (trLabel)L2.Controls[pictureBox1.Controls.Count - 1];
    L3.Text = theText;
    L3.ForeColor = Color.FromArgb(200, 255, 255, 234);
    L3.Location = new Point(-1,-1);  // do not change relative postion in the 2nd label!
