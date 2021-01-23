    private int? _localeId;
    private int? _timeZoneCode;
	/// <summary>
    /// Retrive the local time from the UTC time.
    /// </summary>
    /// <param name="utcTime"></param>
    private void RetrieveLocalTimeFromUTCTime(DateTime utcTime)
    {
        RetrieveCurrentUsersSettings();
        if (!_timeZoneCode.HasValue)
            return;                
        var request = new LocalTimeFromUtcTimeRequest
        {
            TimeZoneCode = _timeZoneCode.Value,
            UtcTime = utcTime.ToUniversalTime()
        };
        var response = (LocalTimeFromUtcTimeResponse)_serviceProxy.Execute(request);
        var localTime = response.LocalTime.ToString("MM/dd/yyyy HH:mm:ss");
        var utcTime = utcTime.ToString("MM/dd/yyyy HH:mm:ss");
        var localDateOnly = response.LocalTime.ToString("dd-MM-yyyy");
    }
    /// <summary>
    /// Retrieves the current users timezone code and locale id
    /// </summary>
    private void RetrieveCurrentUsersSettings()
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
         _localeId = currentUserSettings.LocaleId;
         _timeZoneCode = currentUserSettings.TimeZoneCode;
    }
