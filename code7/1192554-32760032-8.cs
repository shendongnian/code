    protected override void OnMouseMove(MouseEventArgs e) {
        if (e.Button == MouseButtons.Left && this.TabCount > 1) {
            var delta = SystemInformation.DoubleClickSize;
            if (Math.Abs(e.X - downPos.X) >= delta.Width ||
                Math.Abs(e.Y - downPos.Y) >= delta.Height) {
                startDragging();
            }
        }
        base.OnMouseMove(e);
    }
