    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
        Exception exception = e.Exception;
        _Logger.Error(e.Exception, "An unhandled forms application exception occurred");
        // Show the same default dialog
        if (SystemInformation.UserInteractive)
        {
            using (ThreadExceptionDialog dialog = new ThreadExceptionDialog(exception))
            {
                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;
            }
            Application.Exit();
            Environment.Exit(0);
        }
    }
