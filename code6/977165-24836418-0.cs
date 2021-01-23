    public class Helper
    {
        #region appSettings
        public static IsolatedStorageSettings appSettings;
        #endregion
        //This function is used to insert Key,Value pair information in the Isolated Storage memory
        #region InsertDetailInMemory
        public static void InsertDetailInMemory(string key, object value)
        {
            try
            {
                appSettings = IsolatedStorageSettings.ApplicationSettings;
                if (!appSettings.Contains(key))
                    appSettings.Add(key, value);
                else
                    appSettings[key] = value;
                appSettings.Save();
            }
            catch (Exception) { }
        }
        #endregion
        //This function is used to remove Key,Value pair information from the Isolated Storage memory
        #region RemoveDetailInMemory
        public static void RemoveDetailInMemory(string key)
        {
            appSettings = IsolatedStorageSettings.ApplicationSettings;
            if (appSettings.Contains(key))
            {
                appSettings.Remove(key);
                appSettings.Save();
            }
        }
        #endregion
        //This function is used to check the existing of Key,Value pair information in the Isolated Storage memory
        #region IsExistKeyInMemory
        /// <summary>
        /// Check if Specified Key Is Exists or not
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>true if it exists otherwise return false</returns>
        public static bool IsExistKeyInMemory(string key)
        {
            appSettings = IsolatedStorageSettings.ApplicationSettings;
            if (appSettings.Contains(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        //This function is used to get Key,Value pair information from the Isolated Storage memory
        #region GetDetailFromMemory
        /// <summary>
        /// Get value from memory of Specified Key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>value as Object of Specified Key</returns>
        public static object GetDetailFromMemory(string key)
        {
            object value = string.Empty;
            try
            {
                appSettings = IsolatedStorageSettings.ApplicationSettings;
                if (appSettings.Contains(key))
                {
                    value = appSettings[key];
                }
                return value;
            }
            catch (Exception)
            {
                return value;
            }
        }
        #endregion
    }
}
