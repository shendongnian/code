    var datadb1 = DateTime.Parse(dateTimePicker1.Value.ToShortDateString()); 
    var timedb1 = DateTime.Parse(dateTimePicker2.Value.ToShortTimeString());
    
    DateTime datetimeCombined1 = datadb1 + new TimeSpan(timedb1.Hour, 
                                                        timedb1.Minute,
                                                        timedb1.Second);
