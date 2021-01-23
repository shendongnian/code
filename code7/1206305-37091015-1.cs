	public static void RegisterTelemetryInstrumentationKey()
	{
		if (string.IsNullOrWhiteSpace(AppSettings.TelemetryInstrumentationKey))
		{
			TelemetryConfiguration.Active.DisableTelemetry = true;
		}
		else
		{
			TelemetryConfiguration.Active.InstrumentationKey = AppSettings.TelemetryInstrumentationKey;
		}
	}
