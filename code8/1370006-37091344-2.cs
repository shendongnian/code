    foreach (var val in DataSource)
            {
                if (roomNo.Equals(val.Classroom))
                {
                    if (weekDay.Equals(val.ClassRoomWeekDay))
                    {
                        if (startsAt>= val.StartTime && startsAt< val.StartTime )
                        {
                            check = false;
                        }
                        
                    }
                }
                
            }
