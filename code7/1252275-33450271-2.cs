     List<string> itemSubjects = new List<string>();
        foreach (Outlook.AppointmentItem appt in rangeAppts)
        {
            if(string.IsNullOrEmpty(appt.Subject)
            {
               itemSubjects.Add( appt.Subject);
             }
        }
        CheckedList dialog = new CheckedList(itemSubjects);
        dialog.ShowDialog();
