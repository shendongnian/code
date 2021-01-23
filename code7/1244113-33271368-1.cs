    // Useless example since TryEnterFullScreenMode is in the UniversalApiContract
    // and so guaranteed to be there in all Windows 10 apps
    bool isEnterFullScreenPresent = Windows.Foundation.Metadata.ApiInformation.IsMethodPresent("Windows.UI.ViewManagement.ApplicationView", "TryEnterFullScreenMode");
    if (isEnterFullScreenPresent)
    {
        ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
    }
