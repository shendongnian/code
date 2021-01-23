    public class CustomDateTimeConverter : ITypeConverter<DateTime, DateTime> {
        public DateTime Convert(ResolutionContext context) {
            var inputDate = (DateTime) context.SourceValue;
            var timeInUtc = DateTime.SpecifyKind(inputDate, DateTimeKind.Utc);
            return TimeZoneInfo.ConvertTime(timeInUtc, TimeZoneInfo.Local);
        }
    }
