	/// <summary>
    /// Retrive the local time from the UTC time.
    /// </summary>
    /// <param name="utcTime"></param>
    private DateTime RetrieveLocalTimeFromUTCTime(DateTime utcTime)
    {
        int? timeZoneCode = RetrieveCurrentUsersSettings();
        if (!timeZoneCode.HasValue)
            return;                
        var request = new LocalTimeFromUtcTimeRequest
        {
            TimeZoneCode = timeZoneCode.Value,
            UtcTime = utcTime.ToUniversalTime()
        };
        var response = (LocalTimeFromUtcTimeResponse)_serviceProxy.Execute(request);
        return response.LocalTime;
        //var utcTime = utcTime.ToString("MM/dd/yyyy HH:mm:ss");
        //var localDateOnly = response.LocalTime.ToString("dd-MM-yyyy");
    }
    /// <summary>
    /// Retrieves the current users timezone code and locale id
    /// </summary>
    private int? RetrieveCurrentUsersSettings()
    {
        var currentUserSettings = _serviceProxy.RetrieveMultiple(
        new QueryExpression(UserSettings.EntityLogicalName)
        {
            ColumnSet = new ColumnSet("localeid", "timezonecode"),
            Criteria = new FilterExpression
            {
                Conditions =
                {
                    new ConditionExpression("systemuserid", ConditionOperator.EqualUserId)
                }
            }
         }).Entities[0].ToEntity<UserSettings>();
         
         return currentUserSettings.TimeZoneCode;
    }
