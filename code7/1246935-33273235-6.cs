    public static MediaElement MediaElement;
    private void OnLaunched(LaunchActivatedEventArgs e)
    {
        ServiceLocator.Instance.Register<IMediaElementService, MediaElementService>();
    }
