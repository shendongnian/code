    protected override void OnMouseDown(MouseEventArgs e) {
        for (int ix = 0; ix < this.TabCount; ++ix) {
            if (this.GetTabRect(ix).Contains(e.Location)) {
                this.SelectedIndex = ix;
                break;
            }
        }
        downPos = e.Location;
        base.OnMouseDown(e);
    }
