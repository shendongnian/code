    [JsonProperty(ItemConverterType = typeof(CustomDateTimeConverter))]
    public DateTime? DateTime1;
    class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public MonthDayYearDateConverter()
        {
            DateTimeFormat = "MM.dd.yyyy";//specify your format
        }
    }
