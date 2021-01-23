    float angle = 0f;
    float aSpeed = 4f;                      // <-- set your speed
    Brush brush1 = Brushes.CadetBlue;       // and your..
    Brush brush2 = Brushes.DarkSlateBlue;   // ..colors
    private void timer1_Tick(object sender, EventArgs e)
    {
        angle += aSpeed;
        if (angle + aSpeed > 360)
        {
            angle -= 360f;
            Brush temp = brush1;
            brush1 = brush2;
            brush2 = temp;
        }
        pictureBox1.Invalidate();
    }
    private void pictureBox1_Click(object sender, EventArgs e)
    {
        timer1.Enabled = !timer1.Enabled;
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        Rectangle r = pictureBox1.ClientRectangle;
        r.Inflate(-20, -20);     // a little smaller that the panel or pBox
        if (angle < 180)
        {
            e.Graphics.FillEllipse(brush1, r);
            e.Graphics.FillPie(brush2, r, 270, 180);
            r.Inflate(-(int)(r.Width * angle / 360f), 0);
            e.Graphics.FillEllipse(brush2, r);
        }
        else
        {
            e.Graphics.FillEllipse(brush2, r);
            e.Graphics.FillPie(brush1, r, 90, 180);
            r.Inflate(-(int)(r.Width * angle / 360f), 0);
            e.Graphics.FillEllipse(brush1, r);
        }
    }
