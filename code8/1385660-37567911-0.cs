    public abstract class AdminModule : NancyModule
    {
        public AdminModule() : base("/admin"){}
        public AdminModule(string path) : base("/admin/" + path.TrimStart('/')){}
    }
