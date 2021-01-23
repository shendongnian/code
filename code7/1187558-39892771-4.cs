    private void CreateOutlookAppointment(List<string> emailRecipients, string whereIsIt, string briefTitle, string fullDetails, DateTime whenDoesItStart, DateTime whenShouldItFinish)
    {
        try
        { 
            Microsoft.Office.Interop.Outlook.Application ApplicationInstance = null;
            Microsoft.Office.Interop.Outlook.AppointmentItem AppointmentInstance = null;
            ApplicationInstance = new Microsoft.Office.Interop.Outlook.Application();
            AppointmentInstance = (Microsoft.Office.Interop.Outlook.AppointmentItem) ApplicationInstance.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);
            foreach (string EmailRecipient in emailRecipients)
            {
                AppointmentInstance.Recipients.Add(EmailRecipient);
            }
            AppointmentInstance.Subject = briefTitle;
            AppointmentInstance.Body = fullDetails;
            AppointmentInstance.Location = whereIsIt;
            AppointmentInstance.Start = whenDoesItStart;
            AppointmentInstance.End = whenShouldItFinish;
            AppointmentInstance.ReminderSet = true;
            AppointmentInstance.ReminderMinutesBeforeStart = 15;
            AppointmentInstance.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
            AppointmentInstance.BusyStatus = Microsoft.Office.Interop.Outlook.OlBusyStatus.olBusy;
            AppointmentInstance.Save();
            AppointmentInstance.Send();
        }
        catch (Exception ex)
        {
            ex.HandleException();
        }
    }
