    private void CreateOutlookAppointment(List<string> emailRecipients, string whereIsIt, string briefTitle, string fullDetails, DateTime whenDoesItStart, DateTime whenShouldItFinish, bool isItAtYourDesk)
    {
        try
        { 
            Microsoft.Office.Interop.Outlook.Application app = null;
            Microsoft.Office.Interop.Outlook.AppointmentItem appt = null;
            app = new Microsoft.Office.Interop.Outlook.Application();
            appt = (Microsoft.Office.Interop.Outlook.AppointmentItem) app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);
            foreach (string Recipient in emailRecipients)
            {
                appt.Recipients.Add(Recipient);
            }
            appt.Subject = briefTitle;
            appt.Body = fullDetails;
            appt.Location = whereIsIt;
            appt.Start = whenDoesItStart;
            appt.End = whenShouldItFinish;
            appt.ReminderSet = true;
            appt.ReminderMinutesBeforeStart = isItAtYourDesk ? 2 : 15;
            appt.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
            appt.BusyStatus = isItAtYourDesk ? Microsoft.Office.Interop.Outlook.OlBusyStatus.olFree : Microsoft.Office.Interop.Outlook.OlBusyStatus.olBusy;
            appt.Save();
            appt.Send();
        }
        catch (Exception ex)
        {
            ex.HandleException();
        }
    }
