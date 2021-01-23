    public void RegisterMessenger()
    {
        Messenger.Default.Register<NotificationMessage>(this, (message) =>
        {
            MessageBox.Show(message.Notification);
            // Checks the actual content of the message.
            switch (message.Notification)
            {
                case "GoToLoginPage":
                    CurrentPageViewModel= _loginViewModel;
                    break;
                case "GoToRegisterPage":
                    CurrentPageViewModel= _registerViewModel;
                    break;
            }
        });
    }
