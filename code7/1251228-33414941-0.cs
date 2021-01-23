	using (RegistryKey system = Registry.LocalMachine.OpenSubKey("System"))
	using (RegistryKey currentControlSet = system.OpenSubKey("CurrentControlSet"))
	using (RegistryKey services = currentControlSet.OpenSubKey("Services"))
	using (RegistryKey service = services.OpenSubKey(_settings.ServiceName, true))
	{
		service.SetValue("Description", _settings.Description);
		var imagePath = (string)service.GetValue("ImagePath");
		_log.DebugFormat("Service path: {0}", imagePath);
		imagePath += _arguments;
		_log.DebugFormat("Image path: {0}", imagePath);
		service.SetValue("ImagePath", imagePath);
	}
