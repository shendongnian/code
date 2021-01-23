    public static IList<SongPlay> LoadAudioList(string AudioListKey)
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        if (!settings.Contains(AudioListKey)) throw new NotImplementedException(); // do something - list doesnt exist
        return settings[AudioListKey] as IList<SongPlay>;
    }
