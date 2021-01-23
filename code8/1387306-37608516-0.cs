    IDictionary<string, object> jobData = new Dictionary<string, object> { { "QuestionId", questionId } };
    var questionDate = new DateTime(2016, 09, 01);
    var questionTriggerName = string.Format("Question{0}_Trigger", questionId);
    var questionTrigger = TriggerBuilder.Create()
        .WithIdentity(questionTriggerName, "QuestionSendGroup")
        .StartAt(questionDate)
        .UsingJobData(new Quartz.JobDataMap(jobData))
        .Build();
    scheduler
        .ScheduleJob(questionSenderJob, questionTrigger);
