    var res = Context.AccountLogs.Select(s => new {
        s.TimeStamp
    ,   Dto = new LogSummaryDto() {
            UserId = s.User.Id,
            DisplayName = s.User.DisplayName
        }
    ).Concat(Context.SpellLog.Select(s => new {
        s.TimeStamp
    ,   Dto = new LogSummaryDto() {
            UserId = s.User.Id,
            DisplayName = s.User.DisplayName
        }
    )).Concat(Context.Log.Select(s => new {
        s.TimeStamp
    ,   Dto = new LogSummaryDto() {
            UserId = s.User.Id,
            DisplayName = s.User.DisplayName
        }
    )).Where(s => s.TimeStamp > fromDate)
    .Select(p => p.Dto);
