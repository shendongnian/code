    ToastContent tc = new ToastContent()
    {
        Visual = new ToastVisual()
        {
            TitleText = new ToastText()
            {
                Text = "Quick Save"
            },
            BodyTextLine1 = new ToastText()
            {
                Text = "Type below the info that you wanna save and press enter"
            }
        },
        Actions = new ToastActionsCustom()
        {
            Inputs =
            {
                new ToastTextBox("nameBox")
                {
                    PlaceholderContent = "type here"
                }
            },
            Buttons =
            {
                new ToastButton("save", "save")
                {
                    TextBoxId = "nameBox",
                    ImageUri = "Assets/check.png"
                }
            }
        }
    };
    var text = tc.GetContent();
    var xml = tc.GetXml();
    var toast = new ToastNotification(xml);
    ToastNotificationManager.CreateToastNotifier().Show(toast);
