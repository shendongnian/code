    public override UIElement CreateRootElement(IActivatedEventArgs e)
    {
        var b = Current;
        var frame = new Windows.UI.Xaml.Controls.Frame();
        var nav = b.NavigationServiceFactory(BackButton.Attach, ExistingContent.Include, frame);
        
        //change background
        var background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Gray);
        background.Opacity = 0.2;
    
        return new Template10.Controls.ModalDialog
        {
            ModalBackground = background,
            DisableBackButtonWhenModal = true,
            Content = nav.Frame
        };
    }
