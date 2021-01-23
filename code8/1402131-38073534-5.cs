	Timer t = new Timer();
	t.Interval = 14;
	t.Tick += delegate
	{
		if (ShowHideToggle.Checked)
		{
			if (this.Width > 30) // Set Form.MinimumSize to this otherwise the Timer will keep going, so it will permanently try to decrease the size.
				this.Width -= 10;
			else
				t.Stop();
		}
		else
		{
			if (this.Width < 300)
				this.Width += 10;
			else
				t.Stop();
		}
	};
