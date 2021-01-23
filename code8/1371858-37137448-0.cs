     [Table(Name = "AppSettings")]
    public class AppSetting
    {
        [Column(Name = "Id", IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column(Name = "SettingName")]
        public string SettingName;
        [Column(Name = "SettingValue", UpdateCheck = UpdateCheck.Never)]
        public string SettingValue;
        public AppSetting()
        {
            SettingName = String.Empty;
            SettingValue = String.Empty;
        }
    }
