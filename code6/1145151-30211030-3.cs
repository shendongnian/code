    Action callback = ui.CldOnPhoneNumberSent;
    var app = Application.Current;
    if (app == null)
    {
        // This prevents unexpected exceptions being thrown during shutdown (or domain unloading).
        return;
    }
    if (app.CheckAccess())
    {
        // Already on the correct thread, just execute the action
        callback();
    }
    else
    {
        // Invoke through the dispatcher
        app.Dispatcher.Invoke(callback);
    }
