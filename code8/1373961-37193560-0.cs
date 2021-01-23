    var s = conn.Insert(new Buses()
        {
            number = Id.Text,
            stops = stops.Add(new Stop { StopName = StopName.Text, Timetable = Time.Text });
        }
 
