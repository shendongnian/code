    public class ViewModel
    {
       public FiscalPeriod FiscalPeriod { get; set; }
    }
    
    [JsonConverter(typeof(FiscalPeriodConverter))]
    public class FiscalPeriodConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var fiscalPeriod = value as FiscalPeriod;
            writer.WriteStartObject();
            serializer.Serialize(writer, fiscalPeriod.Id);
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(FiscalPeriod).IsAssignableFrom(objectType);
        }
    }
    public class FiscalPeriod
    {
        public FiscalPeriod(int id)
        {
            if (!Validator.IsValidPeriod(id))
                throw new ArgumentException($"Invalid fiscal period ID '{id}'", nameof(id));
            Id = id;
        }
        public int Id { get; private set; }
        public override string ToString() => Id.ToString();
        public static implicit operator int(FiscalPeriod period) => period.Id;
    }
