    /// <summary>
	/// Application settings
	/// Limit to 200*4095
	/// </summary>
	private const string SET_STR = "SETTINGS";
	private const int CHUNK_SIZE = 4095;
	static private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
	static private string AppSettings {
		get {
			string set = "";
			for (int i = 0;i < 200;i++) {
				string s = (string)localSettings.Values[SET_STR + i];
				if (s != null) {
					set += s;
				} else {
					break;
				}
			}
			return set;
		}
		set {
			for (int i = 0;i < 200;i++) {
				localSettings.Values[SET_STR + i] = null;
			}
			for (int i = 0;i * CHUNK_SIZE < value.Length;i++) {
				if (value.Length > i * CHUNK_SIZE) {
					int len = (i + 1) * CHUNK_SIZE > value.Length ? value.Length % CHUNK_SIZE : CHUNK_SIZE;
					localSettings.Values[SET_STR + i] = value.Substring(i * CHUNK_SIZE, len);
				}
			}
		}
	}
