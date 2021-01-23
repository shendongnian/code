    IBuildServer IBS = tpc.GetService<IBuildServer>();
    IBuildDefinition ibdef = IBS.CreateBuildDefinition(projectname);
    ibdef.Name = "ApiDef";
    ibdef.TriggerType = DefinitionTriggerType.ScheduleForced;
    ISchedule iss = ibdef.AddSchedule();
    iss.DaysToBuild = ScheduleDays.Friday;
    iss.StartTime = 10800;
    iss.TimeZone = TimeZoneInfo.Utc;
    ibdef.Save();
