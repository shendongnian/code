	public class UnlockFeaturesPageViewModel : AbstractPageViewModel
	{
		public UnlockFeaturesPageViewModel(ITelemetryService telemetryService,
			   IDataService dataservice) :
			   base(telemetryService, dataservice,
			   CurrentPageEnum.UnlockFeatures)
	}
