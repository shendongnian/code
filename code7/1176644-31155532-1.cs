	if (isDayBookProcessing)
	{
		// Daybook processing code here 
		Task.Factory.StartNew(() =>  _factory
            .AzureFactory
            .ServiceBus
            .ProcessDaybookQueue(queueName, billingTaskId, numOfItemsEnqueued));  
	}
	else
	{
		// Run queue process async   
		Task.Factory.StartNew(() => _factory
            .AzureFactory
            .ServiceBus
            .ProcessBillingQueue(queueName, billingTaskId, numOfItemsEnqueued));
	}
