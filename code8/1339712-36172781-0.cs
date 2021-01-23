    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        ControlPaint.DrawCheckBox(e.Graphics, 11, 11, 22, 22, ButtonState.Checked);
        ControlPaint.DrawCheckBox(e.Graphics, 11, 44, 33, 33, ButtonState.Checked);
        ControlPaint.DrawCheckBox(e.Graphics, 11, 88, 44, 44, ButtonState.Checked);
    }
