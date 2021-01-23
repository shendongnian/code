    using Newtonsoft.Json;
    public class Product
    {
        public string webroot { get; set; }
        public string version { get; set; }
        public Dependencies dependencies { get; set; }
        public string[] exclude { get; set; }
    }
    public class Dependencies
    {
        [JsonProperty("EntityFramework.SqlServer")]
        public string EntityFrameworkSqlServer { get; set; }
        [JsonProperty("EntityFramework.Commands")]
        public string EntityFrameworkCommands { get; set; }
        [JsonProperty("Microsoft.AspNet.Mvc")]
        public string MicrosoftAspNetMvc { get; set; }
    }
