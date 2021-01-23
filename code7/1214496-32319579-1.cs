    private void BorderLessForm_Resize(object sender, EventArgs e)
    {
        var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
        region.Exclude(new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance));
        this.panel1.Region = region;
    }
