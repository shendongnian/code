    public MainPage()
    {
        this.InitializeComponent();
    
        systemControls = SystemMediaTransportControls.GetForCurrentView();
        systemControls.ButtonPressed += SystemControls_ButtonPressed;
        mediaElement.CurrentStateChanged += MediaElement_CurrentStateChanged;
        // Register to handle the following system transpot control buttons.
        systemControls.IsPlayEnabled = true;
        systemControls.IsPauseEnabled = true;
    }
    
    private void MediaElement_CurrentStateChanged(object sender, RoutedEventArgs e)
    {
        switch (mediaElement.CurrentState)
        {
            case MediaElementState.Playing:
                systemControls.PlaybackStatus = MediaPlaybackStatus.Playing;
                break;
            case MediaElementState.Paused:
                systemControls.PlaybackStatus = MediaPlaybackStatus.Paused;
                break;
            case MediaElementState.Stopped:
                systemControls.PlaybackStatus = MediaPlaybackStatus.Stopped;
                break;
            case MediaElementState.Closed:
                systemControls.PlaybackStatus = MediaPlaybackStatus.Closed;
                break;
            default:
                break;
        }
    }
    void SystemControls_ButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs args)
    {
        switch (args.Button)
        {
            case SystemMediaTransportControlsButton.Play:
                PlayMedia();
                break;
            case SystemMediaTransportControlsButton.Pause:
                PauseMedia();
                break;
            case SystemMediaTransportControlsButton.Stop:
                StopMedia();
                break;
            default:
                break;
        }
    }
    
    private async void StopMedia()
    {
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            mediaElement.Stop();
        });
    }
    
    async void PlayMedia()
    {
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            if (mediaElement.CurrentState == MediaElementState.Playing)
                mediaElement.Pause();
            else
                mediaElement.Play();
        });
    }
    
    async void PauseMedia()
    {
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            mediaElement.Pause();
        });
    }
