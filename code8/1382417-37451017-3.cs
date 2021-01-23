    List<Alarm> alarmList = ctx.Alarm.Where(t => t.TimeStamp >= span)
                               .Where(s => s.Active)
                               .GroupBy(g => new { g.Group, g.Id })
                               .OrderByDescending(c => c.Count())
                               .SelectMany(a => a).ToList(); 
