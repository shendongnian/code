    var s = conn.Insert(new Buses()
	{
		number = Id.Text,
		stops = new List<Stop>() 
		{
			new Stop { StopName = StopName.Text, Timetable = Time.Text }),
		}
	}
