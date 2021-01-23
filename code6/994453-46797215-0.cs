	//Apply the correct icon
	if (icon != MessageBoxIcon.None)
	{
		PictureBox pbIcon = new PictureBox();
		pbIcon.SizeMode = PictureBoxSizeMode.AutoSize;
		switch (icon)
		{
			case MessageBoxIcon.Asterisk:
				pbIcon.Image = SystemIcons.Asterisk.ToBitmap();
				break;
			case MessageBoxIcon.Question:
				pbIcon.Image = SystemIcons.Question.ToBitmap();
				break;
		}
		pbIcon.Location = new Point(0, 0);
		this.Controls.Add(pbIcon);
		pbIcon.BringToFront();
	}
