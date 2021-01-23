    [JsonProperty(ItemConverterType = typeof(CustomDateTimeConverter))]
    public DateTime? DateTime1;
    class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            DateTimeFormat = "MM.dd.yyyy";//specify your format
        }
    }
