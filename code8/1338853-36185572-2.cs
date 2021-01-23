                NameValueCollection config = (NameValueCollection)ConfigurationManager.GetSection("quartz");
                ShowConfiguration(config, logger);
                ISchedulerFactory factory = new StdSchedulerFactory(config);
                IScheduler sched = factory.GetScheduler();
    /* the below code has to be tweaked for YOUR Job */
            IJobDetail textFilePoppingJobJobDetail = JobBuilder.Create<TextFilePoppingNonConcurrentJob>()
                .WithIdentity("textFilePoppingJobJobDetail001", "groupName007")
                                .UsingJobData("JobDetailParameter001", "Abcd1234")
                .Build();
            ITrigger textFilePoppingJobJobDetailTrigger001 = TriggerBuilder.Create()
              .WithIdentity("textFilePoppingJobJobDetailTrigger001", "groupName007")
              .UsingJobData("TriggerParameter001", "Bcde2345")
              .UsingJobData("TempDirectorySubFolderName", "MyTempDirectorySubFolderName")
              .UsingJobData("DestinationFullFolderName", @"C:\SomeFolder")
              .StartNow()
              .WithSimpleSchedule(x => x
                  .WithIntervalInSeconds(10)
                  .RepeatForever()
                /* .WithRepeatCount(1) */
                  )
              .Build();
            sched.ScheduleJob(textFilePoppingJobJobDetail, textFilePoppingJobJobDetailTrigger001);
