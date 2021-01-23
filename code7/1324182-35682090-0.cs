	ToolTip tt = new ToolTip();
	void ShowComboBox_ToolTip()
	{
		Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
		int titleHeight = screenRectangle.Top - this.Top;
		Point p = cbAddWing.Location;
		p.X += screenRectangle.Left - this.Left;
		p.Y += titleHeight + cbAddWing.Height;
		p.Y += 5;                           // ToolTip is display below Combobox 5px
		string str = "String " + Environment.TickCount;
		IWin32Window win = this;
		tt.Show(
			str,                            // ToolTip string
			win,                            // Your window
			p,                              // Position
			5000                            // Duration in miliseconds
			);
	}
	private void cbAddWing_TextChanged(object sender, EventArgs e)
	{
		ShowComboBox_ToolTip();
	}
	private void cbAddWing_Enter(object sender, EventArgs e)
	{
		ShowComboBox_ToolTip();
	}
