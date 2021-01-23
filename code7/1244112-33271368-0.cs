    var view = ApplicationView.GetForCurrentView();
    TypeInfo t = typeof(ApplicationView).GetTypeInfo();
    var tryEnterFullScreenMode = t.GetDeclaredMethod("TryEnterFullScreenMode");
    if (tryEnterFullScreenMode != null)
    {
        tryEnterFullScreenMode.Invoke(view, null);
    }
