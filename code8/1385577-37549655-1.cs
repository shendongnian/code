    // Blue button.
    Button bbutton = new Button();
    bbutton.Text = "Button";
    bbutton.BackColor = Color.Blue;
    bbutton.Dock = DockStyle.Fill;
    tableLayoutPanel.Controls.Add(button, 0, 0);
    tableLayoutPanel.Controls.Add(label, 0, 1);
    tableLayoutPanel.Controls.Add(textBox, 1, 0);
    // We added this one.
    tableLayoutPanel.Controls.Add(bbutton, 1, 1);
    tableLayoutPanel.Dock = DockStyle.Fill;
