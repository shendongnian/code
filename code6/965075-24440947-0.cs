    protected override void OnMouseClick(MouseEventArgs e)
    {
        UpdateValue(e)
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left) UpdateValue(e);
    }
    private void UpdateValue(MouseEventArgs e) {
        Value = Min + (e.X / this.Width * (Max - Min));
    }
