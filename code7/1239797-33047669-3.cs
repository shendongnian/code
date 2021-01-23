    var query = model.Users.Select(
        user =>
            new UserStatistics
            {
                FullName = user.FullName,
                Assigned = user.Alarms.Count,
                Resolved = user.Alarms.Count(alarm => alarm.Resolved),
                Unresolved = user.Alarms.Count(alarm => !alarm.Resolved)
            });
    var result = query.ToList();
