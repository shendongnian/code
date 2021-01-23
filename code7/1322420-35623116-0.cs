    var result = db.TransactionLogs
        .GroupBy(_ => new {
            _.UserId, _.CompanyId, DbFunctions.TruncateTime(_.CreatedTime)})
        .Select(_ => new { 
            _.UserId, _.CompanyId, DbFunctions.TruncateTime(_.CreatedTime), 
            Total = _.Sum(t => t.TimeSpentMins)});
