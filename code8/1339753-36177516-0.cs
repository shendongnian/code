    protected override void OnAppearing()
    {
        MessagingCenter.Subscribe<OpenMyPageMessage>(this, OpenMyPageMessage.Key, (sender) =>
            {
                Detail = new YourAnotherPage();
            });
    }
    
    protected override void OnDisappearing()
    {
        MessagingCenter.Unsubscribe<OpenMyPageMessage>(this, OpenMyPageMessage.Key);
    }
