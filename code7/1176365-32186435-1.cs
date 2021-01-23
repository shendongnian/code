	protected async override void OnLaunched(LaunchActivatedEventArgs e)
	{
		...
		// Install the VCD
		try
		{
			StorageFile vcdStorageFile = await Package.Current.InstalledLocation.GetFileAsync(@"HomeControlCommands.xml");
			await VoiceCommandDefinitionManager.InstallCommandDefinitionsFromStorageFileAsync(vcdStorageFile);
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine("There was an error registering the Voice Command Definitions", ex);
		}
	}
