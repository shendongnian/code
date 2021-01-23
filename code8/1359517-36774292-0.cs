    var builder = new ConfigurationSourceBuilder();
    
        builder.ConfigureLogging()
          .LogToCategoryNamed("General")
          .WithOptions.SetAsDefaultCategory()                   
          .SendTo.RollingFile("Log File")
          .RollEvery(Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.RollInterval.Day)
          .UseTimeStampPattern("yyyyMMdd")
          .WhenRollFileExists(Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.RollFileExistsBehavior.Overwrite)
          .FormatWith(new FormatterBuilder()
                .TextFormatterNamed("Text Formatter")
                .UsingTemplate("{message}"))
         .ToFile(SettingsHelper.LogFilePath)                         
         .WithHeader(string.Empty)
         .WithFooter(string.Empty);                         
    
          var configSource = new DictionaryConfigurationSource();
          builder.UpdateConfigurationWithReplace(configSource);
          EnterpriseLibraryContainer.Current = EnterpriseLibraryContainer.CreateDefaultContainer(configSource);
