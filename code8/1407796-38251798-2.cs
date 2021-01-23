    foreach (var item in temp)
    {
        Panel pan = new Panel();
        pan.Padding = new Padding(5);
        pan.AutoSize = true;
        pan.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        pan.BackColor = (Color)cc.ConvertFromString("#" + item.Item3);
        Label lbl = new Label();
        lbl.Dock = DockStyle.Fill;
        lbl.Font = new Font("Arial", 12);
        lbl.ForeColor = Color.White;
        lbl.Text = item.Item2;
        lbl.AutoSize = true;
        lbl.MaximumSize = new Size(pan.Width - 5, 0);
        pan.Controls.Add(lbl);
        flowLayoutPanel1.Controls.Add(pan);
        location = new Point(location.X - pan.Height, location.Y);
    }
