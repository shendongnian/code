    private async void viewActivated(CoreApplicationView sender, IActivatedEventArgs args1)
	{
		try
		{
			FileOpenPickerContinuationEventArgs args = args1 as FileOpenPickerContinuationEventArgs;
			if (args != null)
			{
				if (args.Files.Count == 0) return;
				view.Activated -= viewActivated;
				if (args.Files.Count > 0)
				{
					// Application now has read/write access to the picked file(s)
					foreach (StorageFile file in args.Files)
					{				
						// Launch file.
						bool filelaunch = await Windows.System.Launcher.LaunchFileAsync(file);
					}
				}
			}
		}
		catch (Exception ex)
		{ }
	}
