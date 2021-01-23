    public void SaveSettings(string tabName)
    {
        Settings.Default.ReleaseTrackSideFormat = StateManager.ReleaseTrackSideFormat;
        Settings.Default.ReleaseLabelCopyFormat = StateManager.ReleaseLabelCopyFormat;
        Settings.Default.ReleaseExportDestination = StateManager.ReleaseExportDestination;
        Settings.Default.ReleaseSearchOptions = new SerializableReleaseSearchOptions(ReleaseSearchOptions);
        ...
        Settings.Default.Save();
    }
    public void LoadSettings()
    {
        Settings.Default.Reload();
        StateManager.ReleaseTrackSideFormat = Settings.Default.ReleaseTrackSideFormat;
        StateManager.ReleaseLabelCopyFormat = Settings.Default.ReleaseLabelCopyFormat;
        StateManager.ReleaseExportDestination = Settings.Default.ReleaseExportDestination;
        ReleaseSearchOptions = new ReleaseSearchOptions(Settings.Default.ReleaseSearchOptions);
        ReleaseExportSearchOptions = new ReleaseExportSearchOptions(Settings.Default.ReleaseExportSearchOptions);
        ...
    }
