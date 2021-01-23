    [DataContract(Namespace = ContractNamespace.Current)]
    public class CreditSpreadShiftWithLevels
    {
        [OnDeserializing]
        private void Initialize(StreamingContext ctx)
        {
            ShiftsByRating = new Dictionary<CreditRating, double>();
        }
        [DataMember]
        public bool SplitByRating { get; set; }
        [DataMember]
        public double ShiftValue { get; set; }
        [DataMember]
        [JsonConverter(typeof(CreditRatingDoubleDictionaryConverter))]
        public Dictionary<CreditRating, double> ShiftsByRating { get; set; }
     
        //other properties
    }
    [DataContract(Namespace = ContractNamespace.Current)]
    public struct CreditRating
    {
        public CreditRating(string json): this()
        {
            var levels = json.Split(new[] { '~' }, StringSplitOptions.None);
            var cnt = levels.Length;
            if (cnt >= 3) Level3 = levels[2];
            if (cnt >= 2) Level2 = levels[1];
            if (cnt >= 1) Level1 = levels[0];
        }
        [DataMember]
        public string Level1 { get; set; }
        [DataMember]
        public string Level2 { get; set; }
        [DataMember]
        public string Level3 { get; set; }
        public override string ToString()
        {
            return string.Format("{0}~{1}~{2}", Level1, Level2, Level3);
        }
    }
    public class CreditRatingDoubleDictionaryConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dict = new Dictionary<CreditRating, double>();
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    string readerValue = reader.Value.ToString();
                    var cr = new CreditRating(readerValue);
                    if (reader.Read() && reader.TokenType == JsonToken.Float)
                    {
                        var val = Convert.ToDouble(reader.Value);
                        dict.Add(cr, val);
                    }
                }
                if (reader.TokenType == JsonToken.EndObject) return dict;
            }
            return dict;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(Dictionary<CreditRating, double>).IsAssignableFrom(objectType);
        }
    }
