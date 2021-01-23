    Messenger.Default.Register<NotificationMessage>(this, HandleMessage);
    private async void HandleMessage(NotificationMessagemessage)
    {
        ... code using await
    }
