    public class LocalDateTimeConvention : IMemberMapConvention
    {
        public string Name
        {
            get { return "LocalDateTime"; }
        }
        public void Apply(BsonMemberMap memberMap)
        {
            if (memberMap.MemberType == typeof(DateTime))
            {
                var dateTimeSerializer = new DateTimeSerializer(DateTimeKind.Local);
                memberMap.SetSerializer(dateTimeSerializer);
            }
            else if (memberMap.MemberType == typeof(DateTime?))
            {
                var dateTimeSerializer = new DateTimeSerializer(DateTimeKind.Local);
                var nullableDateTimeSerializer = new NullableSerializer<DateTime>(dateTimeSerializer);
                memberMap.SetSerializer(nullableDateTimeSerializer);
            }
        }
    }
