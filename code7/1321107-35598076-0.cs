            Object selObject = this.Application.ActiveExplorer().Selection[1];
            if (selObject is Outlook.MailItem)
            {
                Outlook.MailItem mailItem =
                    (selObject as Outlook.MailItem);
                itemMessage = "The item is an e-mail message." +
                    " The subject is " + mailItem.Subject + ".";
                mailItem.Display(false);
            }
            else if (selObject is Outlook.ContactItem)
            {
                Outlook.ContactItem contactItem =
                    (selObject as Outlook.ContactItem);
                itemMessage = "The item is a contact." +
                    " The full name is " + contactItem.Subject + ".";
                contactItem.Display(false);
            }
            else if (selObject is Outlook.AppointmentItem)
            {
                Outlook.AppointmentItem apptItem =
                    (selObject as Outlook.AppointmentItem);
                itemMessage = "The item is an appointment." +
                    " The subject is " + apptItem.Subject + ".";
            }
            else if (selObject is Outlook.TaskItem)
            {
                Outlook.TaskItem taskItem =
                    (selObject as Outlook.TaskItem);
                itemMessage = "The item is a task. The body is "
                    + taskItem.Body + ".";
            }
            else if (selObject is Outlook.MeetingItem)
            {
                Outlook.MeetingItem meetingItem =
                    (selObject as Outlook.MeetingItem);
                itemMessage = "The item is a meeting item. " +
                     "The subject is " + meetingItem.Subject + ".";
            }
