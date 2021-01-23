    private void OnOpenHttpLinkCommand()
    {
        try
        {
            System.Diagnostics.Process.Start("http://www.google.com/");
        }
        catch (Exception)
        {
            // TODO: Error.
        }
    }
