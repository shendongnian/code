    ToastContent content = new ToastContent()
    {
        Visual = new ToastVisual()
        {
            TitleText = new ToastText()
            {
                Text = "Alarm"
            },
            BodyTextLine1 = new ToastText()
            {
                Text = "Wake up"
            }
        },
        Scenario = ToastScenario.Alarm,
        Audio = new ToastAudio()
        {
            Src = new Uri("ms-winsoundevent:Notification.Looping.Alarm")
        },
        Actions = new ToastActionsCustom()
        {
            Buttons =
            {
               new ToastButtonSnooze(),
               new ToastButtonDismiss()
            }
        }
    };
