    private void checkMeetings()
    {
        string[] split = User.Identity.Name.Split('\\');
        string userTag = split[1];
        Active_Directory ad = new Active_Directory();
        string creator = ad.convertForUserInfo(userTag, "email");
        ExchangeService service = new ExchangeService();
        service.AutodiscoverUrl(creator);
        CalendarFolder folder = CalendarFolder.Bind(service, WellKnownFolderName.Calendar);
        CalendarView view = new CalendarView(Convert.ToDateTime("03.08.2015 08:00"),Convert.ToDateTime("08.08.2015 08:00"));
        FindItemsResults<Appointment> results = folder.FindAppointments(view);
        service.LoadPropertiesForItems(appointments, new PropertySet(BasePropertySet.IdOnly, AppointmentSchema.Subject, AppointmentSchema.Start, AppointmentSchema.RequiredAttendees));
        foreach (Appointment appointment in results)
        {
            foreach (Attendee attendee in appointment.RequiredAttendees)
            {
                Test2.Text += attendee.Name + " " + attendee.ResponseType + "***";
            }
        }
    }
