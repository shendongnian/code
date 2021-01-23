    public class ImageInfos
    {
        [JsonProperty]
        private string Path;
        [JsonProperty]
        private string Type;
        [JsonProperty]
        private string DateModified;
        public ImageInfos(string Path, string Type, string DateModified)
        {
            this.Path = Path;
            this.Type = Type;
            this.DateModified = DateModified;
        }
    }
