        private void Form1_Load(object sender, EventArgs e)
		{
			var _col = this.Controls;
			List<ComboBox> _box = new List<ComboBox>();
			List<Object> _boxItems = new List<Object>();
			foreach (var a in _col)
			{
				if (a is ComboBox)
				{
					_box.Add((ComboBox)a);
				}
			}
			foreach (var a in _box)
			{
				_boxItems.Add(a.Items);
			}
		}
