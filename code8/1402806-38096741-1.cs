    private void button1_Click(object sender, EventArgs e)
    {
        // lets add a few buttons..
        for (int i = 0; i < 25; i++)
        {
            Button btn = new Button();
            btn.Top = i * 25;
            panel2.Controls.Add(btn); // Add to panel2 instead of panel1
        }
        // Recalculate size of the panel in the scrollable panel
        panel2.Height = panel2.Controls.Cast<Control>().Max(x => x.Top + x.Size.Height);
        panel2.Width = panel2.Controls.Cast<Control>().Max(x => x.Left + x.Size.Width);
    }
