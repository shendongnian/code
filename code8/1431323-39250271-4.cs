    // Add Panels to TableLayoutPanel
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < cols; j++)
		{
			// Create new Panel
			Panel space = new Panel()
			{
				Size = new Size(45, 45),
				Dock = DockStyle.Fill,
				Margin = new Padding(0),
				ForeColor = Color.Red
			};
			space.MouseClick += new MouseEventHandler(MouseDownOnSpace);
			CustomLabel info = new CustomLabel(false, 0, Color.Empty, Color.Red);  // Create new CustomLabel
			space.Controls.Add(info);   // Add CustomLabel to Panel
			tlp.Controls.Add(space, j, i);      // Add Panel to TableLayoutPanel
		}
	}
