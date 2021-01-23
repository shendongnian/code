		PropertyGrid pg = new PropertyGrid() { Dock = DockStyle.Fill };
		Control c = pg.Controls[0]; // internal DocComment control
		Label l1 = (Label) c.Controls[1];
		RichTextBox tb = new RichTextBox { Multiline = true, WordWrap = true, ReadOnly = true, BorderStyle = BorderStyle.None };
		c.Controls.Add(tb);
		c.Controls.SetChildIndex(tb, 0);
		l1.TextChanged += delegate {
			tb.Text = l1.Text;
		};
		l1.SizeChanged += delegate {
			tb.Size = l1.Size;
		};
		l1.LocationChanged += delegate {
			tb.Location = l1.Location;
		};
