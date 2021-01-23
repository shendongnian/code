    private void Form_Para_VisibleChanged(object sender, EventArgs e)
    {
        this.Location = new Point(this.Location.X, _TriggerControlPosBottom.Y);
        if (_TriggerControlPosBottom.Y + this.Height > Screen.PrimaryScreen.Bounds.Height)
        {
            this.Location = new Point(this.Location.X, _TriggerControlPosTop.Y - this.Height);
        } 
    }
