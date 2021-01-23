    public static class LogSummaryDtoExtensions {
        public static IEnumerable<LogSummaryDto> ExtractSummaryDtos(this IEnumerable<ILog> logs, DateTime fromDate) {
            return logs.Where(s => s.Timestamp > fromDate).Select(s => new LogSummaryDto {
                UserId = s.User.Id,
                DisplayName = s.User.DisplayName
            });
        }
    }
