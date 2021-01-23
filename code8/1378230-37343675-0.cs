    private async void Add-Click(object sender, RoutedEventArgs e)
    {
        // Create an Appointment that should be added the user's appointments provider app.
        var appointment = new Windows.ApplicationModel.Appointments.Appointment();
        appointment.StartTime = timeconversion.AddMinutes(-10);
        appointment.Location = sharingProgramTime; // appointment location
        appointment.Subject = sharingProgramName; // appointment subject
        appointment.Details = sharingProgramName  + sharingProgramTime; // appointment details
        appointment.IsAllDayEvent = false;
        appointment.Reminder = new TimeSpan(0,10,0); // Ten minutes
        appointment.BusyStatus = AppointmentBusyStatus.Busy;
 
        // Get the selection rect of the button pressed to add this appointment
        var rect = GetElementRect(sender as FrameworkElement);
    
        // ShowAddAppointmentAsync returns an appointment id if the appointment given was added to the user's calendar.
        // This value should be stored in app data and roamed so that the appointment can be replaced or removed in the future.
        // An empty string return value indicates that the user canceled the operation before the appointment was added.
        String appointmentId = await Windows.ApplicationModel.Appointments.AppointmentManager.ShowAddAppointmentAsync(
                               appointment, rect, Windows.UI.Popups.Placement.Default);
    }
