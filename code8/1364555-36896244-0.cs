    public class Rootobject
    {
        public string Version { get; set; }
        public User[] Users { get; set; }
    }
    public class User
    {
        public string UserName { get; set; }
        public string[] Following { get; set; }
    }
