    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		if (BackupStillRunning)
		{
			if (MessageBox.Show("The backup is still running, if you close the application, the backup will be cancelled. Do you want to proceed?", "Caption", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				e.Cancel = true;
		}
		else
		{
			e.Cancel = false;
		}
	}
