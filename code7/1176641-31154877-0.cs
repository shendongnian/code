    if (isDayBookProcessing)
    {
        // Daybook processing code here 
        Task.Run(() => _factory.AzureFactory.ServiceBus.ProcessDaybookQueue(
                               queueName, 
                               billingTaskId, 
                               numOfItemsEnqueued));  
    }
    else
    {
        // Run queue process async   
        Task.Run(() => _factory.AzureFactory.ServiceBus.ProcessBillingQueue(
                               queueName,
                               billingTaskId, 
                               numOfItemsEnqueued));
    } 
 
