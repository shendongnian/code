    public class UnlockFeaturesPageViewModel : ViewModelBase 
    {
        public UnlockFeaturesPageViewModel(ITelemetryService telemetryService,
           IDataService dataservice)
            : base(telemetryService, dataservice, CurrentPageEnum.UnlockFeatures)
        {
        }
    }
