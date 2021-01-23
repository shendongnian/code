			Form f = new Form();
			Panel parent = new Panel { Dock = DockStyle.Top, BackColor = Color.Blue, AutoSize = true  };
			FlowLayoutPanel p1 = new FlowLayoutPanel { FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight };
			p1.BackColor = Color.Red;
			p1.AutoSize = true;
			p1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			Button b1 = new Button { Text = "Button1", AutoSize = true, AutoEllipsis = false };
			p1.Controls.Add(b1);
			b1.Click += delegate {
				Button b2 = new Button { Text = "Button" + (p1.Controls.Count + 1), AutoSize = true, AutoEllipsis = false };
				p1.Controls.Add(b2);
			};
			parent.Controls.Add(p1);
			f.Controls.Add(parent);
			Application.Run(f);
