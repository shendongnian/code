	// Make sure you have this.
		using System.Linq;
	public class BottomAlignTextBox : Panel
	{
		public BottomAlignTextBox()
		{
			this.BackColor = Color.White;
			this.BorderStyle = (Application.RenderWithVisualStyles) ? BorderStyle.FixedSingle : BorderStyle.Fixed3D;
			this.Size = new Size(200, 200);
			this.Padding = new Padding(5, 0, 4, 2);
			bottomAlignTextBox.Dock = DockStyle.Bottom;
			bottomAlignTextBox.Multiline = true;
			bottomAlignTextBox.WordWrap = true;
			bottomAlignTextBox.AcceptsReturn = true;
			bottomAlignTextBox.BorderStyle = BorderStyle.None;
			bottomAlignTextBox.Height = 20;
			bottomAlignTextBox.TextChanged += delegate
			{
				if (bottomAlignTextBox.Height < this.Height - 20)
				{
					if (TextRenderer.MeasureText(bottomAlignTextBox.Text, bottomAlignTextBox.Font).Width > bottomAlignTextBox.Width + 6)
					{
						string longestLine = bottomAlignTextBox.Lines.OrderByDescending(s => TextRenderer.MeasureText(s, bottomAlignTextBox.Font).Width).First();
						bottomAlignTextBox.Text = bottomAlignTextBox.Text.Replace(longestLine, longestLine.Substring(0, longestLine.Length - 1) + Environment.NewLine + longestLine[longestLine.Length - 1]); 
						bottomAlignTextBox.Height += 19;
						bottomAlignTextBox.SelectionStart = bottomAlignTextBox.Text.Length + 2;
						bottomAlignTextBox.SelectionLength = 0;
					}
				}
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
