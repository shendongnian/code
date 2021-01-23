    [ProtoContract]
    public class DateTimeOffsetSurrogate
    {
        [ProtoMember(1)]
        public string DateTimeString { get; set; }
        public static implicit operator DateTimeOffsetSurrogate(DateTimeOffset value)
        {
            return new DateTimeOffsetSurrogate { DateTimeString = value.ToString("o") };
        }
        public static implicit operator DateTimeOffset(DateTimeOffsetSurrogate value)
        {
            try
            {
                return DateTimeOffset.Parse(value.DateTimeString, null, DateTimeStyles.RoundtripKind);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to parse date time value: " + value.DateTimeString, ex);
            }
        }
    }
