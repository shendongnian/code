        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e) {
            for (int ix = 0; ix < tabControl1.TabCount; ++ix) {
                if (tabControl1.GetTabRect(ix).Contains(e.Location)) {
                    // Found it, do something
                    //...
                }
            }
        }
