    private void button1_Click_1(object sender, EventArgs e)
    {
        Panel p = new Panel();
        p.Location = new Point(10, 10);
        p.Height = 200;
        p.Width = 200;
        p.BorderStyle = BorderStyle.Fixed3D;
        Controls.Add(p);
        NumericUpDown nud = new NumericUpDown();
        nud.Location = new Point(150, 150);
        nud.Height = 100;
        nud.Width = 100;
        Controls.Add(nud);
        nud.BringToFront();
    }
