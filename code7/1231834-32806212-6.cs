	public class WaterMarkTextBox : TextBox
	{
		ToolTip TTip = new ToolTip();
		private string _WaterMark = string.Empty;
		public string WaterMark
		{
			get { return _WaterMark; }
			set
			{
				if (value == null) value = string.Empty;
				if (_WaterMark == value) return;
				_WaterMark = value;
				if (this.DesignMode || this.ContainsFocus) return;
				this.Text = _WaterMark;
				this.ForeColor = SystemColors.GrayText;
			}
		}
		private string _Tip;
		public string Tip
		{
			get { return _Tip; }
			set { _Tip = value; }
		}
		public WaterMarkTextBox()
		{
			this.Leave += new System.EventHandler(this._Leave);
			this.Enter += new System.EventHandler(this._Enter);
			this.MouseHover += new EventHandler(WaterMarkTextBox_MouseHover);
		}
		private void _Leave(object sender, EventArgs e)
		{
			if (this.Text.Length == 0)
			{
				this.Text = _WaterMark;
				this.ForeColor = SystemColors.GrayText;
			}
		}
		private void _Enter(object sender, EventArgs e)
		{
			if (this.Text == _WaterMark)
			{
				this.Text = "";
				this.ForeColor = SystemColors.WindowText;
			}
		}
		private void WaterMarkTextBox_MouseHover(object sender, EventArgs e)
		{
			if (Tip != null)
				TTip.Show(Tip, this, 0, (int)(this.Height * 1.2), 2000);
		}
	}
 
