    this.MessengerInstance.Register<LoginSuccessMessage>(this, this.OnLoginSuccessMessage);
    private async void OnLoginSuccessMessage(LoginSuccessMessage message)
        {
            this.CurrentUserName = message.UserName;
        }
