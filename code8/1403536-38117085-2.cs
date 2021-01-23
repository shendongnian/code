	public class BottomAlignTextBox : Panel
	{
		public BottomAlignTextBox()
		{
			this.BackColor = Color.White;
			this.BorderStyle = (Application.RenderWithVisualStyles) ? BorderStyle.FixedSingle : BorderStyle.Fixed3D;
			this.Size = new Size(200, 200);
			this.Padding = new Padding(5, 0, 2, 2);
			
			bottomAlignTextBox.Dock = DockStyle.Bottom;
			bottomAlignTextBox.Multiline = true;
			bottomAlignTextBox.WordWrap = false;
			bottomAlignTextBox.BorderStyle = BorderStyle.None;
			bottomAlignTextBox.Height = 20;
			
			bottomAlignTextBox.TextChanged += delegate
			{
				string[] lines = bottomAlignTextBox.Lines;
				if (lines.Length != 0)
				{
					if (TextRenderer.MeasureText(lines[lines.Length - 1], bottomAlignTextBox.Font).Width > bottomAlignTextBox.Width)
					{
						if (bottomAlignTextBox.Height < this.Height - 20)
							bottomAlignTextBox.Height += 19;
					}
				}
				bottomAlignTextBox.Text = string.Join(Environment.NewLine, lines);
			};
			
			this.Controls.Add(bottomAlignTextBox);
			this.Click += delegate { bottomAlignTextBox.Focus(); };
		}
		
		public new string Text
		{
			get { return bottomAlignTextBox.Text; }
			set { bottomAlignTextBox.Text = value; }
		}
		
		private TextBox bottomAlignTextBox = new TextBox();
	}
