    var m2 = new List<IEnumerable<dynamic>> {AccountLogs, SpellLogs, Logs}
        .SelectMany(x => x.Where(y => y.Timestamp > fromDate).Select(s => new LogSummaryDto {
            UserId = s.User.Id,
            DisplayName = s.User.DisplayName
        }));
