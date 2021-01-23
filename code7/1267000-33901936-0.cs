    protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
    {
        EmailService myEmailService = new EmailService();
        Container.RegisterInstance<IMyService>(myEmailService);
        NavigationService.Navigate("Main", null);
        return Task.FromResult(true);
    }
