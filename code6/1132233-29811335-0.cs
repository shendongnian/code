	bool FlagDisplay(PictureBox team, string teamName)
	{
		var images = new Dictionary<string, string>()
		{
			{ "Canada", Properties.Resources.Canada },
			{ "New Zealand", Properties.Resources.NZ },
			{ "South Africa", Properties.Resources.RSA },
		};
		if (images.ContainsKey(teamName))
		{
			team.Image = new Bitmap(images[teamName]);
			return true;
		}
		return false;
	}
