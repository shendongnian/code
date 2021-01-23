    private static string FindWordVersion()
    {
        var application = new Microsoft.Office.Interop.Word.Application();
        try
        {
            string version = application.Version;
            return version;
        }
        finally
        {
            application.Quit(SaveChanges: false);
        }
    }
