    private void tabControl1_MouseClick(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Right) {
            for (int ix = 0; ix < tabControl1.TabCount; ++ix) {
                if (tabControl1.GetTabRect(ix).Contains(e.Location)) {
                    tabControl1.TabPages[ix].Dispose();
                    break;
                }
            }
        }
    }
