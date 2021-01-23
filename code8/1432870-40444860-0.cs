            var triggerSet = new Quartz.Collection.HashSet<ITrigger>();
            var saferWatchJobDetail = JobBuilder.Create<SaferWatchProcessor>().Build();
            var swtriggerMorning = TriggerBuilder.Create().WithCronSchedule("0 10 6 ? * MON-SUN *", cs => cs.InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"))).Build();
            var swtriggerAfternoon = TriggerBuilder.Create().WithCronSchedule("0 10 13 ? * MON-FRI *", cs => cs.InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"))).Build();
            triggerSet.Add(swtriggerMorning);
            triggerSet.Add(swtriggerAfternoon);
            this.scheduler.ScheduleJob(saferWatchJobDetail, triggerSet, true);
