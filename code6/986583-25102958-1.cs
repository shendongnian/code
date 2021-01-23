    public static void LoadAudioList(string AudioListKey, ref IList<SongPlay> target)
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        if (!settings.Contains(AudioListKey)) throw new NotImplementedException(); // do something - list doesnt exist
        target = settings[AudioListKey] as IList<SongPlay>;
    }
