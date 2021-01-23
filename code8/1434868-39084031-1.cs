    services.AddMvc()
		.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
		.AddDataAnnotationsLocalization()
		.AddRazorOptions(options =>
		{  
			options.FileProviders.Add(new EmbeddedFileProvider(
				typeof(SiteManager).GetTypeInfo().Assembly,
				"cloudscribe.Core.Web"
			));
		})
		;
