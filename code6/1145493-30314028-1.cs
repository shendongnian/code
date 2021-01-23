		services.AddMvc().ConfigureRazorViewEngine(options =>
		{
			var oldRoot = ApplicationEnviroment.ApplicationBasePath;
			var trimmedRoot = oldRoot.Remove(oldRoot.LastIndexOf('\\'));
			options.FileProvider = new PhysicalFileProvider(trimmedRoot);
		});
