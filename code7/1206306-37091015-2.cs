	public static void RegisterTelemetryInstrumentationKey()
	{
		if (string.IsNullOrWhiteSpace(WebConfigurationManager.AppSettings["TelemetryInstrumentationKey"])
		{
			TelemetryConfiguration.Active.DisableTelemetry = true;
		}
		else
		{
			TelemetryConfiguration.Active.InstrumentationKey = AppSettings.TelemetryInstrumentationKey;
		}
	}
