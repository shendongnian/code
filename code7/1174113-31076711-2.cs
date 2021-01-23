    public static List<Appointment> GetAppointment()
    {
        //snip
        List<Appointment> appointments = GetAllAppointments()
        //Use some Linq to project into your own model
        return appointments
            .Select(a => new AppointmentModel
            {
                Title = a.Title,
                Body = a.Body,
                MeetingTime = a.MeetingTime
            });
    }
