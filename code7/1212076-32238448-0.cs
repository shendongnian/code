    Outlook.Items items = seCalendar.Items;
    for (int i = 1; i <= items.Count; i++)
    {
      object item = items[i];
      Outlook.AppointmentItem appt = item as Outlook.AppointmentItem;
      if (apt != null)
      {
         MessageBox.Show(appt.Subject);
         Marshal.ReleaseComObject(appt);
      }
      Marshal.ReleaseComObject(item);
    }
