    public class AppSettings
    {
        public int NoRooms { get; set; }
        public string Uri { get; set; }
    }
    services.Configure<AppSettings>(Configuration.GetSection("appsettings"));
