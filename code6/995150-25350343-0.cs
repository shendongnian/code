    public class ModList{
        [JsonProperty("modid")]
        public String ModeId { get; set; }
    	[JsonProperty("name")]
        public String Name { get; set; }
    	[JsonProperty("description")]
        public String Description { get; set; }
    	[JsonProperty("version")]
        public String Version { get; set; }
    	[JsonProperty("mcversion")]
        public String McVersion { get; set; }
    	[JsonProperty("url")]
        public String Url { get; set; }
    	[JsonProperty("updateUrl")]
        public String UpdateUrl { get; set; }
    	[JsonProperty("authorList")]
        public List<String> AuthorList { get; set; }
    	[JsonProperty("credits")]
        public String Credits { get; set; }
    	[JsonProperty("logoFile")]
        public String LogFile { get; set; }
    	[JsonProperty("screenshots")]
        public List<object> ScreenShots { get; set; }
    	[JsonProperty("parent")]
        public String Parent { get; set; }
    	[JsonProperty("requiredMods")]
        public List<String> RequiredMods { get; set; }
    	[JsonProperty("dependencies")]
        public List<String> Dependencies { get; set; }
    	[JsonProperty("dependants")]
        public List<object> Dependants { get; set; }
    	[JsonProperty("useDependencyInformation")]
        public String UseDependencyInformation { get; set; }
    }
    public class McMod{
    	[JsonProperty("modListVersion")]
        public Int32 ModListVersion { get; set; }
    	[JsonProperty("modList")]
        public List<ModList> Mods { get; set; }
    }
 
