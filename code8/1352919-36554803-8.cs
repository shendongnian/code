    var pictureToRemove = this.Controls.OfType<PictureBox>().Where(x => x.Location.X == r * 65 + 15 && x.Location.Y == c * 65 + 60).FirstOrDefault();
    if (grid[r, c].value == 1)
    {
        if (pictureToRemove != null) 
        {
			pictureToRemove.Image = White;
		}
		else 
		{
	        var picbox = new PictureBox()                // initialise picturebox for displaying images
	        {
	            Name = grid[r, c].name,
	            Size = new Size(64, 64),
	            Location = new Point(r * 65 + 15, c * 65 + 60),
	            Text = grid[r, c].name,
	            Image = White
	        };
	        Controls.Add(picbox);                // add picturebox to form 
	        picbox.Click += ClickBox;
		}
        MessageBox.Show("white draw" + grid[r, c].name);
    }
