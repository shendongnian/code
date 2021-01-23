        // Summary:
        //     Gets the last modified timestamp associated with the resource.
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "_ts")]
        public virtual DateTime Timestamp { get; internal set; }
