    public async static Task RegisterBackgroundAgentAsync(string time)
        {
            var Datetime = DateTime.ParseExact(time, "HHmm", new System.Globalization.CultureInfo("en-US"));
            var taskname = "BackgroundAgentTask";
            var builder = new BackgroundTaskBuilder();
            builder.Name = taskname;
            builder.TaskEntryPoint = "BackgroundAgent.BackgroundAgentTask";
            TimeSpan ts = Datetime - DateTime.ParseExact(DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00"), "HHmm", new CultureInfo("en-US"));
            if (ts.TotalMinutes < 15)
            {
               if (ts.TotalMinutes < 0)
               {
                   if (1440 + ts.TotalMinutes > 15)
                      builder.SetTrigger(new TimeTrigger((uint)(1440 + ts.TotalMinutes), false));
                   else
                      builder.SetTrigger(new TimeTrigger(15, false));
               }
               else
               {
                   if (ts.TotalMinutes == 0)
                       builder.SetTrigger(new TimeTrigger(1440, false));
                   else
                       builder.SetTrigger(new TimeTrigger(15, false));
               }
            }
            else
                builder.SetTrigger(new TimeTrigger((uint)ts.TotalMinutes, false));
            BackgroundTaskRegistration result;	
            var bas = (await BackgroundExecutionManager.RequestAccessAsync());
            if (bas == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity)
                result = builder.Register();
        }
