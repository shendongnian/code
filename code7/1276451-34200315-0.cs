    var m = new List<dynamic>().Concat(AccountLogs).Concat(SpellLogs).Concat(Logs)
                .Where(s => s.Timestamp > fromDate)
                .Select(s => new LogSummaryDto {
                    UserId = s.User.Id,
                    DisplayName = s.User.DisplayName
                });
