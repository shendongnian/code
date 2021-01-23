    Random R = new Random();
    private void button5_Click(object sender, EventArgs e)
    {
        Panel p = new Panel();
        p.Name = "panel" + flowLayoutPanel1.Controls.Count + 1;
        p.BackColor = Color.FromArgb(123, R.Next(222), R.Next(222));
        p.Size = new Size(flowLayoutPanel1.ClientSize.Width, 50);
        flowLayoutPanel1.Controls.Add(p);
        flowLayoutPanel1.Controls.SetChildIndex(p, 0);  // this move the new one to the top!
    }
