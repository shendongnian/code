            string sendText = "";
            string subject = "";
            string location = "";
            string emails = {"dsqdsqdqsd@dsqdqd.com", "sdqdqdqd@dqsd.com"};
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Outlook.AppointmentItem appt = (Outlook.AppointmentItem)app.CreateItem(Outlook.OlItemType.olAppointmentItem);
            appt.Subject = subject;
            appt.MeetingStatus = Outlook.OlMeetingStatus.olMeeting;
            appt.Location = location;
            appt.Start = DateTime.Now.AddHours(1);
            appt.End = DateTime.Now.AddHours(3);
            appt.AllDayEvent = false;
            appt.Body = sendText;
            appt.ResponseRequested = false;
            foreach (string email in emails)
            {
                Outlook.Recipient recipRequired = appt.Recipients.Add(email);
                recipRequired.Type = (int)Outlook.OlMeetingRecipientType.olRequired;
            }
            appt.Recipients.ResolveAll();
            appt.Display(true);
            try
            {
                Outlook.MAPIFolder calendar = Data.OutlookHelper.AdxCalendar.getCallendar(app, @"\\Fichier de données Outlook\Calendrier\Methode");
                appt.Move(calendar);
            }
            catch
            {
                Dialogs.Alert alert = new Dialogs.Alert("Erreur", "Le rendez-vous est introuvable, vous l'avez peut-être supprimer.");
                alert.ShowDialog();
            }
