    private void Add_Click(object sender, RoutedEventArgs e)
    {
		var bus = new Buses()
        {
            number = Id.Text,
		};
		bas.stops.Add(new Stop { StopName = StopName.Text, Timetable = Time.Text });
        var s = conn.Insert(bus);
	}
