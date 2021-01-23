    /// <summary>
    /// Class for pipeline settings
    /// </summary>
    public class PipelineSettings
    {
        public PipelineSettings()
        {
            this.Credentials = new List<PipelineCredentials>();
        }
    
        /// <summary>
        /// List of jobs to process
        /// </summary>
        [JsonProperty("jobs")]
        public List<PipelineJob> Jobs;
    
        // todo: make private and create FetchCredentials(id)
        /// <summary>
        /// List of credentials information cataloged by id
        /// </summary>
        [JsonProperty("credentials")]
        public List<PipelineCredentials> Credentials;
    }
