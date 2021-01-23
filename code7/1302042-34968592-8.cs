    public class Natives
    {
        public string linux { get; set; }
        public string windows { get; set; }
        public string osx { get; set; }
    }
    public class Extract
    {
        public List<string> exclude { get; set; }
    }
    public class Os
    {
        public string name { get; set; }
    }
    public class Rule
    {
        public string action { get; set; }
        public Os os { get; set; }
    }
    public class Library
    {
        public string name { get; set; }
        public Natives natives { get; set; }
        public Extract extract { get; set; }
        public List<Rule> rules { get; set; }
    }
    public class RootObject
    {
        public string id { get; set; }
        public string time { get; set; }
        public string releaseTime { get; set; }
        public string type { get; set; }
        public string minecraftArguments { get; set; }
        public int minimumLauncherVersion { get; set; }
        public string assets { get; set; }
        public List<Library> libraries { get; set; }
        public string mainClass { get; set; }
    }
