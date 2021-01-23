      private readonly static Lazy<App> _instance = new Lazy<App>(
            () => new App(GlobalHost.ConnectionManager.GetHubContext<AppHub>().Clients));
        private readonly ConcurrentDictionary<string, User> _users = new ConcurrentDictionary<string, User>(StringComparer.OrdinalIgnoreCase);
        private IHubConnectionContext Clients { get; set; }
        public App(IHubConnectionContext clients)
        {
            Clients = clients;
        }
