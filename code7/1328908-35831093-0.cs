    public class BackupData
    {
        public List<Vehicles> Vehicles { get; private set; }
        public List<FuelStops> FuelStops { get; private set; }
        public BackupData(List<Vehicles> vehicles, List<FuelStops> fuelStops)
        {
            Vehicles = vehicles;
            FuelStops = fuelStops;
        }
        public string ToJson(Formatting formatting = Formatting.None)
        {
            var json = JsonConvert.SerializeObject(this, formatting);
            return json;
        }
        public static BackupData FromJson(string jsonBackupData)
        {
            var data = JsonConvert.DeserializeObject<BackupData>(jsonBackupData);
            return data;
        }
    }
