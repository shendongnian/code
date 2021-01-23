    var cronExpression = "40 * * * * ?";
    ITrigger trigger = TriggerBuilder.Create()
            .WithCronSchedule(cronExpression)
            .Build();
    var humanReadableString = ExpressionDescriptor.GetDescription(cronExpression);
    // humanReadableString = "Every 40 seconds"
