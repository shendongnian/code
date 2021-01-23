    public class ModList {
        public string modid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string version { get; set; }
        public string mcversion { get; set; }
        public string url { get; set; }
        public string updateUrl { get; set; }
        public List<string> authorList { get; set; }
        public string credits { get; set; }
        public string logoFile { get; set; }
        public List<object> screenshots { get; set; }
        public string parent { get; set; }
        public List<string> requiredMods { get; set; }
        public List<string> dependencies { get; set; }
        public List<object> dependants { get; set; }
        public string useDependencyInformation { get; set; } 
    }
    
    public class RootObject {
        public int modListVersion { get; set; }
        public List<ModList> modList { get; set; } 
    }
