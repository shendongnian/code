    DateTime dtTimeOfAppointmentFrom = new DateTime(date.Year, date.Month, date.Day, 08, 00, 00);
    DateTime dtTimeOfAppointmentTo = new DateTime(date.Year, date.Month, date.Day, 16, 00, 00);
    var avTimes = db.AvailableTimes.Where(m => m.TimeOfAppointment >= dtTimeOfAppointmentFrom
                                        && m.TimeOfAppointment <= dtTimeOfAppointmentTo
                                        && m.StateOfBooking == 1
                                        && m.ProviderId == id);
