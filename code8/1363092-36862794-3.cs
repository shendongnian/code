    [Serializable]
    public class propertyClass
    {
        [Description("Server Bağlantı Adı"), Category("Server Setting")]
        public string serverName { get; set; }
        [Description("Server Bağlantısı Dosya Adı"), Category("Server Setting")]
        public string databaseName { get; set; }
        [Description("Server Bağlantısı kullanıcı adı"), Category("Server Setting")]
        public string user { get; set; }
        [Description("Server Bağlantısı kullanıcı şifresi"), Category("Server Setting")]
        public string password { get; set; }
        [Description("Grid Hücre Yükseklik Ayarı \nFormlar Yenilendiğinde etkinleştirilecektir."), Category("Grid Ayarları")]
        public int gridHeight { get; set; }
    }
