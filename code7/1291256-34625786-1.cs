	var booking =
		background.SchedulePeriodic(0, TimeSpan.FromSeconds(1.0), state =>
		{
			var copy = state;
			if (copy % 2 == 0)
			{
				ui.Schedule(() => label1.Text = copy.ToString());
			}
			else
			{
				background.Schedule(() => ui.Schedule(() => label1.Text = "odd"));
			}
			return ++state;
		});
		
	form1.FormClosing += (s, e) => booking.Dispose();
