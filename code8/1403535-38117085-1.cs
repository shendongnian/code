	public class BottomAlignTextBox : Panel
	{
		public BottomAlignTextBox()
		{
			this.BackColor = Color.White;
			this.BorderStyle = (Application.RenderWithVisualStyles) ? BorderStyle.FixedSingle : BorderStyle.Fixed3D;
			
			bottomAlignTextBox.Dock = DockStyle.Bottom;
			bottomAlignTextBox.Multiline = true;
			bottomAlignTextBox.BorderStyle = BorderStyle.None;
			
			bottomAlignTextBox.TextChanged += delegate
			{
				string[] lines = bottomAlignTextBox.Lines;
				
				if (TextRenderer.MeasureText(lines[lines.Length - 1], bottomAlignTextBox.Font).Width > bottomAlignTextBox.Width)
					bottomAlignTextBox.Height = bottomAlignTextBox.Height * 2;
				
				bottomAlignTextBox.Text = string.Join(Environment.NewLine, lines);
			};
			
			this.Controls.Add(bottomAlignTextBox);
			this.Click += delegate { bottomAlignTextBox.Focus(); };
		}
		
		private TextBox bottomAlignTextBox = new TextBox();
	}
