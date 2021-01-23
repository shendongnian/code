	private void CreateBlastHole(string[] pointCoordinate)
    {
        for (int i = 0; i < pointCoordinate.Length; i++)
        {
			PictureBox blastHole = new PictureBox();
			blastHole.Height = 15;
			blastHole.Width = 15;
			blastHole.BackColor = Color.Blue;
            blastHole.Left = int.Parse(pointCoordinate[i]);
            i = i + 1;
            blastHole.Top = int.Parse(pointCoordinate[i]);
            drawingPanel.Controls.Add(blastHole);
			blastHole.Click += new EventHandler(BlastHole_Click);
			ToolTip tooltip1 = new ToolTip();
			// Set up delays for the tooltip
			tooltip1.AutoPopDelay = 5000;
			tooltip1.InitialDelay = 1000;
			tooltip1.ReshowDelay = 500;
			// Force the tooltip text to be displayed whether or not the form is active.
			tooltip1.ShowAlways = true;
			// Set up the tooltip text for the controls
			int axisX = blastHole.Location.X;
			int axisY = blastHole.Location.Y;
			string coordinates = "Точка N " + blastHole.Name + "X = " + axisX.ToString() + " Y = " + axisY.ToString();
			tooltip1.SetToolTip(blastHole, coordinates);
        }
    }
