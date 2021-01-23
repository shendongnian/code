    public class EntryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Entry).IsAssignableFrom(objectType);
        }
        void SetField(Entry entry, int index, JValue value)
        {
            switch (index)
            {
                case 0:
                    entry.DateTime = new DateTime((int)value, entry.DateTime.Month, entry.DateTime.Day, entry.DateTime.Hour, entry.DateTime.Minute, entry.DateTime.Second, entry.DateTime.Millisecond, entry.DateTime.Kind);
                    break;
                case 1:
                    entry.DateTime = new DateTime(entry.DateTime.Year, (int)value, entry.DateTime.Day, entry.DateTime.Hour, entry.DateTime.Minute, entry.DateTime.Second, entry.DateTime.Millisecond, entry.DateTime.Kind);
                    break;
                case 2:
                    entry.DateTime = new DateTime(entry.DateTime.Year, entry.DateTime.Month, (int)value, entry.DateTime.Hour, entry.DateTime.Minute, entry.DateTime.Second, entry.DateTime.Millisecond, entry.DateTime.Kind);
                    break;
                case 3:
                    entry.DateTime = new DateTime(entry.DateTime.Year, entry.DateTime.Month, entry.DateTime.Day, (int)value, entry.DateTime.Minute, entry.DateTime.Second, entry.DateTime.Millisecond, entry.DateTime.Kind);
                    break;
                case 4:
                    entry.DateTime = new DateTime(entry.DateTime.Year, entry.DateTime.Month, entry.DateTime.Day, entry.DateTime.Hour, (int)value, entry.DateTime.Second, entry.DateTime.Millisecond, entry.DateTime.Kind);
                    break;
                case 5:
                    entry.DateTime = new DateTime(entry.DateTime.Year, entry.DateTime.Month, entry.DateTime.Day, entry.DateTime.Hour, entry.DateTime.Minute, (int)value, entry.DateTime.Millisecond, entry.DateTime.Kind);
                    break;
                case 6:
                    entry.Number = (int)value;
                    break;
                case 7:
                    entry.Destination = (string)value;
                    break;
                case 8:
                    entry.TimeZone = (string)value;
                    break; 
                case 9:
                    entry.GmtOffset = (decimal)value;
                    break;
                default:
                    throw new IndexOutOfRangeException(index.ToString());
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var array = JArray.Load(reader);
            if (array == null)
                return existingValue;
            var entry = (existingValue as Entry ?? new Entry());
            for (int i = 0; i < array.Count; i++)
            {
                SetField(entry, i, (JValue)array[i]);
            }
            return entry;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
