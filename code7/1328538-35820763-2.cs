    private void control_Enter(object sender, EventArgs e)
    {
        if (sender is Control)
        {
            var control = (Control)sender;
            Cursor.Position = control.PointToScreen(new Point()
            {
                X = control.Width / 2,
                Y = control.Height / 2
            });
        }
    }
