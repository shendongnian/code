	public void IncreaseHoursBy1()
	{
		this.hours += 1;
		if (this.hours == 8)
		{
			if (AlarmEvent8 != null)
			{
				Console.WriteLine(this.AlarmEvent8("Time to wake up!"));
			}
		}
	}
