    IPluginExecutionContext context = (IPluginExecutionContext)
            serviceProvider.GetService(typeof(IPluginExecutionContext));
    IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
    IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
    // This retrieves the UTC time
    DateTime dateAndTime = (DateTime)dateDeliveryRequiredImage["requestdeliverby"];
    // This converts the UTC time to your local time
    var localDate = RetrieveLocalTimeFromUTCTime(dateAndTime, service);
    // It will give you the correct date
    var date = dateAndTime.ToString("dd-MM-yyyy");
