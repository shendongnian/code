    private async void OnSuspending(object sender, SuspendingEventArgs args)
    {
        suspendDeferral = args.SuspendingOperation.GetDeferral();
        rootPage.NotifyUser("", NotifyType.StatusMessage);
        using (var session = new ExtendedExecutionSession())
        {
            session.Reason = ExtendedExecutionReason.SavingData;
            session.Description = "Pretending to save data to slow storage.";
            session.Revoked += ExtendedExecutionSessionRevoked;
            ExtendedExecutionResult result = await session.RequestExtensionAsync();
            switch (result)
            {
                case ExtendedExecutionResult.Allowed:
                    // We can perform a longer save operation (e.g., upload to the cloud).
                    try
                    {
                        MainPage.DisplayToast("Performing a long save operation.");
                        cancellationTokenSource = new CancellationTokenSource();
                        await Task.Delay(TimeSpan.FromSeconds(10), cancellationTokenSource.Token);
                        MainPage.DisplayToast("Still saving.");
                        await Task.Delay(TimeSpan.FromSeconds(10), cancellationTokenSource.Token);
                        MainPage.DisplayToast("Long save complete.");
                    }
                    catch (TaskCanceledException) { }
                    break;
                default:
                case ExtendedExecutionResult.Denied:
                    // We must perform a fast save operation.
                    MainPage.DisplayToast("Performing a fast save operation.");
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    MainPage.DisplayToast("Fast save complete.");
                    break;
            }
            session.Revoked -= ExtendedExecutionSessionRevoked;
        }
        suspendDeferral?.Complete();
        suspendDeferral = null;
    }
    private async void ExtendedExecutionSessionRevoked(object sender, ExtendedExecutionRevokedEventArgs args)
    {
        //If session is revoked, make the OnSuspending event handler stop or the application will be terminated
        if (cancellationTokenSource != null){ cancellationTokenSource.Cancel(); }
        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            switch (args.Reason)
            {
                case ExtendedExecutionRevokedReason.Resumed:
                    // A resumed app has returned to the foreground
                    rootPage.NotifyUser("Extended execution revoked due to returning to foreground.", NotifyType.StatusMessage);
                    break;
                case ExtendedExecutionRevokedReason.SystemPolicy:
                    //An app can be in the foreground or background when a revocation due to system policy occurs
                    MainPage.DisplayToast("Extended execution revoked due to system policy.");
                    rootPage.NotifyUser("Extended execution revoked due to system policy.", NotifyType.StatusMessage);
                    break;
            }
            suspendDeferral?.Complete();
            suspendDeferral = null;
        });
    }
