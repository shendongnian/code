    #if WINDOWS_PHONE_APP
        private void OnExecuteBackup(SettingsPage obj)
        {
    #else
        private async Task<bool> OnExecuteBackup(SettingsPage obj)
        {
    #endif
            var backupData = App.JournalModel.GetBackupData().ToJson(Formatting.Indented);
            ...
            await SaveBackupFile(file, backupData);
            ...
    public class JournalModel
    {
        ...
        public BackupData GetBackupData()
        {
            var data = new BackupData(Vehicles.ToList(), FuelStops.ToList());
            return data;
        }
        ...
