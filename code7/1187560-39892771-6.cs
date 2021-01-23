    private void CreateOutlookGroupMeetingAppointment(List<string> emailRecipients, string meetingPlace, string shortDescription, string longDescription, DateTime start, DateTime finish)
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
            AppointmentInstance.Subject = shortDescription;
            AppointmentInstance.Body = longDescription;
            AppointmentInstance.Location = meetingPlace;
            AppointmentInstance.Start = start;
            AppointmentInstance.End = finish;
            AppointmentInstance.ReminderSet = true;
            AppointmentInstance.ReminderMinutesBeforeStart = 15;
            AppointmentInstance.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
            AppointmentInstance.BusyStatus = Microsoft.Office.Interop.Outlook.OlBusyStatus.olBusy;
            AppointmentInstance.Save();
            AppointmentInstance.Send();
        }
        catch //(Exception ex)
        {
            //ex.HandleException();
        }
    }
