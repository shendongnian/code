    // get your Reminder Id
    string reminderID = GetReminderID();
    
    ToastContent content = new ToastContent()
    {
        ...
        Actions = new ToastActionsCustom()
        {
            Buttons =
            {
                // set your Reminder ID into the Argument to pass it to the background task
                new ToastButton("Done", reminderID)
                {
                    ActivationType = ToastActivationType.Background,
                }
            }
        },
    };
