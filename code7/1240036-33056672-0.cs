    const long TicksPerWeek = TimeSpan.TicksPerDay * 7;
    var userFiles = files.GroupBy(f => f.LastModUser);
    var userStats = userFiles.Select(u =>
        u.GroupBy(f => file.Date.Ticks / TicksPerWeek)
            .Select(f => new { week = f.Key, modifiedCount = f.Count()))
