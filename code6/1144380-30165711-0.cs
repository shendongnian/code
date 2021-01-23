    	private void tabControl1_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Left) {
				if (tabControl1.SelectedIndex > 0) {
					tabControl1.SelectedIndex--;
				}
			};
			if (e.KeyCode == Keys.Right) {
				if (tabControl1.SelectedIndex < tabControl1.TabCount - 1) {
					tabControl1.SelectedIndex++;
				}
			};
		}
