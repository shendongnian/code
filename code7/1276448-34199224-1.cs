    var res = Context.AccountLogs.Select(s => new {
            s.TimeStamp
        ,   s.User.Id
        ,   s.User.DisplayName
        }).Concat(Context.SpellLog.Select(s => new {
            s.TimeStamp
        ,   s.User.Id
        ,   s.User.DisplayName
        })).Concat(Context.Log.Select(s => new {
            s.TimeStamp
        ,   s.User.Id
        ,   s.User.DisplayName
        }))
        // Selects / Concats above provide uniform structure
        // on which to apply the common Where clause
        .Where(s => s.TimeStamp > fromDate)
        .Select(s => new LogSummaryDto() {
            UserId = s.User.Id
        ,   DisplayName = s.User.DisplayName
        });
