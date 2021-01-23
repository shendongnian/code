    // Registers for incoming Notification messages.
    Messenger.Default.Register<NotificationMessage<Person>>(this, (message) =>
    {
        // Gets the Person object.
        var person = message.Content;
    
        // Checks the associated action.
        switch (message.Notification)
        {
            case "Select":
                break;
            case "Delete":
                break;
            default:
                break;
        }
    });
