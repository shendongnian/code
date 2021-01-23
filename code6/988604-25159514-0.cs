        private async void OnLoginSuccessMessage(LoginSuccessMessage message)
        {
            this.CurrentUserName = message.UserName;
            this.MoveToState(ApplicationViewModelState.Active);
            await Task.Delay(5000);
            this.MoveToState(ApplicationViewModelState.Idle);
        }
