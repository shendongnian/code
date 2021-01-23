You can handle the Closing of the Window like this:
    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		if (BackupStillRunning)
			e.Cancel = true;
		else
			e.Cancel = false;
	}
