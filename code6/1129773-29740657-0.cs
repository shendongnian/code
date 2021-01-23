        private void Form1_Load(object sender, EventArgs e)
		{
			var _col = this.Controls;
			List<ComboBox> _box = new List<ComboBox>();
			for (int i = 0; i < _col.Count; i++)
			{
				if (_col[i] is ComboBox)
				{
					_box.Add((ComboBox)_col[i]);
				}
			}
		}
