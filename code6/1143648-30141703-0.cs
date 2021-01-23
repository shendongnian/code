    public class CustomDateTimeConverter : ITypeConverter<DateTime, DateTime> {
        public DateTime Convert(ResolutionContext context) {
            var timeInUtc = (DateTime) context.SourceValue;
            return TimeZoneInfo.ConvertTime(timeInUtc, TimeZoneInfo.Local);
        }
    }
