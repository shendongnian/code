    public void ClickedButton (object sender, EventArgs e)
    {
        var btn = sender as Button;
        if ((btn != null) && btn.BackColor == System.Drawing.SystemColors.Control)) {
            btn.BackColor = Color.Turquoise;
        }
    }
