        private static async Task<bool> DoBackgroundRequestAccess()
        {
            String appVersion = String.Format("{0}.{1}.{2}.{3}",
                    Package.Current.Id.Version.Build,
                    Package.Current.Id.Version.Major,
                    Package.Current.Id.Version.Minor,
                    Package.Current.Id.Version.Revision);
            if ((string)Windows.Storage.ApplicationData.Current.LocalSettings.Values["AppVersion"] != appVersion)
            {
                // Our app has been updated
                Windows.Storage.ApplicationData.Current.LocalSettings.Values["AppVersion"] = appVersion;
                // Call RemoveAccess
                BackgroundExecutionManager.RemoveAccess();
            }
            BackgroundAccessStatus status = await BackgroundExecutionManager.RequestAccessAsync();
            return status == BackgroundAccessStatus.AlwaysAllowed
                || status == BackgroundAccessStatus.AllowedSubjectToSystemPolicy;
        }
