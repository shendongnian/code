    public class ExtensionManager : Singleton<ExtensionManager>
	{
		#region Constructor
		/// <summary>
		/// private constructor to satisfy the singleton base class
		/// </summary>
		private ExtensionManager()
		{
			ExtensionHomePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Definitions.Constants.FolderName);
			if (!Directory.Exists(ExtensionHomePath))
				Directory.CreateDirectory(ExtensionHomePath);
			SettingsFileFullname = Path.Combine(ExtensionHomePath, Definitions.Constants.SettingsFileName);
			InstallationPath = Path.GetDirectoryName(GetType().Assembly.Location);
		}
		#endregion
		#region Properties
		/// <summary>
		/// returns the installationPath
		/// </summary>
		public string InstallationPath { get; private set; }
		/// <summary>
		/// the path to the directory where the settings file is located as well as the log file
		/// </summary>
		public string ExtensionHomePath { get; private set; }
		/// <summary>
		/// the fullpath to the settingsfile
		/// </summary>
		public string SettingsFileFullname { get; private set; }
		#endregion
	}
