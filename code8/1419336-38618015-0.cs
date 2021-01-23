    this.createAccount.Command = (ICommand)new DelegateCommand(this.ExecuteCreateAccount);
    private async Task ExecuteCreateAccount()
    {
        AppEvent.OnShowNotificationEvent(UTNotificationType.ChangeMainLoaderStatus, "show", null);
        if (this.isCreateAccountProcessing)
        {
            return;
        }
        this.isCreateAccountProcessing = true;
        await this.AccountListViewModel.LoadUsersCollection());
        AppEvent.OnShowNotificationEvent(UTNotificationType.ChangeMainLoaderStatus, null, null);
        this.isCreateAccountProcessing = false;
        if (this.createAccount.IsSelected)
        {
            this.AccountListViewModel.CreateNewItem();
        }
    }
