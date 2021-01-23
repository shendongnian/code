    publicRedemption.RDOAppointmentItem EditOutlookAppointment(CustomAppointment appointment, int retries = 0)
    {
        try
        {
            Outlook.Application outlookApp = new Outlook.Application();
            Redemption.RDOSession session = new Redemption.RDOSession();
            session.MAPIOBJECT = outlookApp.Session.MAPIOBJECT; //share the Outlook session
            RDOFolder calendarFolder = session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar);
            Redemption.RDOAppointmentItem appointmentItem  = calendarFolder.Items.Find("GlobalAppointmentID = '"+appointment.UniqueId + "'");
    
            if (appointmentItem != null)
            {
                    // set some properties
                    appointmentItem.Subject    = appointment.Subject;
                    appointmentItem.Body       = appointment.Body;
                    appointmentItem.Location   = appointment.Location;            //Set the location
                    appointmentItem.Start = appointment.Start;
                    appointmentItem.End   = appointment.End; 
                    appointmentItem.Save();
                    return appointmentItem;
            }
        }
        catch (Exception ex)
        {
                //Error message implementation here
        }
        return null;
    }
