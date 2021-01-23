	public class UnlockFeaturesPageViewModel : AbstractPageViewModel
	{
		public UnlockFeaturesPageViewModel(ITelemetryService telemetryService,
			   IDataService dataservice, CurrentPageEnum currentPage) :  // This one, CurrentPageEnum do not belong here, it's enum and can't be resolved
			   base(telemetryService, dataservice,
			   CurrentPageEnum.UnlockFeatures)
	}
