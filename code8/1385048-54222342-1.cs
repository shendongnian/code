	public class CustomTelemetryInitializer : ITelemetryInitializer
	{
		public void Initialize(ITelemetry telemetry)
		{
			switch (telemetry)
			{
				case RequestTelemetry request when request.ResponseCode == "404":
					request.Success = true;
					break;
			}
		}
	}
