    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        // TODO: Prepare page for display here.
        // TODO: If your application contains multiple pages, ensure that you are
        // handling the hardware Back button by registering for the
        // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
        // If you are using the NavigationHelper provided by some templates,
        // this event is handled for you.
        var testResult = await callRestAPI("~your URL here~");
    }
