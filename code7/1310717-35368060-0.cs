        item = resultItems.GetFirst();
        do
        {
           if (item != null)
           {
               if (item is Outlook._AppointmentItem)
               {
                   counter++;
                   appItem = item as Outlook._AppointmentItem;
                   strBuilder.AppendLine("#" + counter.ToString() +
                                         "\tStart: " + appItem.Start.ToString() +
                                         "\tSubject: " + appItem.Subject +
                                         "\tLocation: " + appItem.Location);
               }
               Marshal.ReleaseComObject(item);
               item = resultItems.GetNext();
           }
       }
       while (item != null);
