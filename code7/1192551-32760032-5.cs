    private void host_MouseCaptureChanged(object sender, EventArgs e) {
        if (draggingHost.Capture) return;
        var pos = this.PointToClient(Cursor.Position);
        for (int ix = 0; ix < this.TabCount; ++ix) {
            if (this.GetTabRect(ix).Contains(pos)) {
                if (ix != this.SelectedIndex) {
                    var page = this.SelectedTab;
                    this.TabPages.RemoveAt(this.SelectedIndex);
                    this.TabPages.Insert(ix, page);
                    this.SelectedIndex = ix;
                }
                break;
            }
        }
        draggingHost.Dispose();
        draggingHost = null;
    }
