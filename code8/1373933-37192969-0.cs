    public class ClientService : Service
    {
        public AppConfig AppConfig { get; set; }
        public HttpResult Post(Person request)
        {
           HttpResult response = new HttpResult();
           var _initConf = AppConfig;
        }
    }
