    private void ClipboardChanged(Object sender, SharpClipboard.ClipboardChangedEventArgs e)
    {
        // Gets the application's executable name.
        Debug.WriteLine(e.SourceApplication.Name);
        // Gets the application's window title.
        Debug.WriteLine(e.SourceApplication.Title);
        // Gets the application's process ID.
        Debug.WriteLine(e.SourceApplication.ID.ToString());
        // Gets the application's executable path.
        Debug.WriteLine(e.SourceApplication.Path);
    }
