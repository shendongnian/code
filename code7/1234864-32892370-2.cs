	public static class LoggingConfigurator
	{
		private const string DebugLoggingConfiguration = @"log4net.debug.config";
		/// <summary>
		/// Configures the logging.
		/// </summary>
		/// <exception cref="System.Configuration.ConfigurationErrorsException">Thrown if the logging configuration does not exist.</exception>
		[SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Console.WriteLine(System.String)")]
		[SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Console.WriteLine(System.String,System.Object)")]
		public static void ConfigureLogging()
		{
			try
			{
				string path = GetLogConfigurationPath();
				var fileInfo = new FileInfo(path);
				if (fileInfo.Exists)
				{
					log4net.Config.XmlConfigurator.ConfigureAndWatch(fileInfo);
					Console.WriteLine("Loaded logging configuration from: {0}", path);
				}
				else
				{
					var message = "Logging configuration does not exist: " + path;
					Console.WriteLine(message);
					throw new ConfigurationErrorsException(message);
				}
			}
			catch (ConfigurationErrorsException ex)
			{
				Console.WriteLine("log4net is not configured:\n{0}", ex);
			}
		}
		/// <summary>
		/// Gets the path to the logging configuration file.
		/// </summary>
		/// <returns>The path to the log configuration file.</returns>
		private static string GetLogConfigurationPath()
		{
			var path = GetPathFromAppConfig();
			var directory = Path.GetDirectoryName(path);
			if (directory != null)
			{
				var debugPath = Path.Combine(directory, DebugLoggingConfiguration);
				if (File.Exists(debugPath))
				{
					return debugPath;
				}
			}
			return path;
		}
		/// <summary>
		/// Gets the log4net configuration path file from the app.config.
		/// </summary>
		/// <returns>The path to the log4net configuration file if found, otherwise <c>null</c>.</returns>
		private static string GetPathFromAppConfig()
		{
			string appConfigPath;
			var xml = LoadAppConfig(out appConfigPath);
			var logSectionNode = GetSection(xml, "Log4NetConfigurationSectionHandler");
			if (logSectionNode == null || logSectionNode.Attributes == null)
			{
				return appConfigPath;
			}
			var attribute = logSectionNode.Attributes["configSource"];
			if (attribute == null || string.IsNullOrEmpty(attribute.Value))
			{
				return appConfigPath;
			}
			// Otherwise return the path to the actual log4net config file.
			return ToAbsolutePath(attribute.Value, appConfigPath);
		}
		/// <summary>
		/// Gets the node for a configurations section from an application configuration.
		/// </summary>
		/// <param name="configuration">The <see cref="XmlDocument"/> representing the application configuration.</param>
		/// <param name="type">The section type.</param>
		/// <returns>The node for the section.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="configuration"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="type"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="type"/> is an empty string.</exception>
		/// <exception cref="ConfigurationErrorsException">The section could not be found in the application configuration.</exception>
		private static XmlNode GetSection(XmlDocument configuration, string type)
		{
			if (configuration == null)
			{
				throw new ArgumentNullException("configuration");
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (type.Length == 0)
			{
				throw new ArgumentException("'type' cannot be an empty string.");
			}
			// Get the name of the section from the type
			const string configSectionFormat = @"/configuration/configSections/section[contains(@type,'{0}')]/@name";
			var configSectionPath = string.Format(CultureInfo.InvariantCulture, configSectionFormat, type);
			var configSectionNode = configuration.SelectSingleNode(configSectionPath);
			if (configSectionNode == null)
			{
				throw new ConfigurationErrorsException("App.config does not have a section with a type attribute containing: " + type);
			}
			// Get the section from the name discovered above
			var sectionName = configSectionNode.Value;
			var sectionNode = configuration.SelectSingleNode(@"/configuration/" + sectionName);
			if (sectionNode == null)
			{
				throw new ConfigurationErrorsException("Section not found in app.config: " + sectionName);
			}
			return sectionNode;
		}
		/// <summary>
		/// Loads the application configuration.
		/// </summary>
		/// <param name="appConfigPath">The path to the application configuration.</param>
		/// <returns>The loaded application configuration as an <see cref="XmlDocument"/>.</returns>
		/// <exception cref="ConfigurationErrorsException">The application configuration could not be loaded.</exception>
		private static XmlDocument LoadAppConfig(out string appConfigPath)
		{
			try
			{
				var xml = new XmlDocument();
				appConfigPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
				xml.Load(appConfigPath);
				return xml;
			}
			catch (Exception ex)
			{
				throw new ConfigurationErrorsException("Could not load app.config.", ex);
			}
		}
		/// <summary>
		/// Converts a path to an absolute path.
		/// </summary>
		/// <param name="path">The path (can be absolute or relative).</param>
		/// <param name="basePath">The base path (used for resolving absolute path).</param>
		/// <returns>The absolute path</returns>
		/// <exception cref="ArgumentException"><paramref name="basePath"/> does not contain a directory.</exception>
		private static string ToAbsolutePath(string path, string basePath)
		{
			if (Path.IsPathRooted(path))
			{
				return path;
			}
			var directory = Path.GetDirectoryName(basePath);
			if (directory == null)
			{
				throw new ArgumentException("'basePath' does not contain a directory.", "basePath");
			}
			return Path.GetFullPath(Path.Combine(directory, path));
		}
	}
