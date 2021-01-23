    foreach (var room in DataSource)
            {
                if (roomNo.Equals(room.Classroom))
                {
                    foreach (var day in DataSource)
                    {
                        if (weekDay.Equals(day.Weekday))
                        {
                            foreach (var time in DataSource)
                            {
                                if (startsAt>= time.StartTime && startsAt< time.EndTime)
                                {
                                    check = false;
                                }
                            }
                        }
                    }
                }
            }
