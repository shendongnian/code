	public event EventHandler PictureClick
	{
		add { pictureBox1.Click += value; }
		remove { pictureBox1.Click -= value; }
	}
