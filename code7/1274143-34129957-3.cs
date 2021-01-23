    public class ShellViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public ShellViewModel(IRegionManager regionManager)
        {
            if (regionManager == null)
                throw new ArgumentNullException("regionManager");
            this.regionManager = regionManager;
            this.OptionSettingConfirmationRequest = new InteractionRequest<IConfirmation>();
            openConnectionOptionsCommand = new DelegateCommand(RaiseConnectionOptionsRequest);
        }
        public InteractionRequest<IConfirmation> OptionSettingConfirmationRequest { get; private set; }
        private readonly ICommand openConnectionOptionsCommand;
        public ICommand OpenConnectionOptionsCommand { get { return openConnectionOptionsCommand; } }
        private void RaiseConnectionOptionsRequest()
        {
            this.OptionSettingConfirmationRequest.Raise(new Confirmation { Title = "Options not saved. Do you wish to save?" }, OnConnectionOptionsResponse);
        }
        protected virtual void OnConnectionOptionsResponse(IConfirmation context)
        {
            if(context.Confirmed)
            {
                // save it
            }
            // otherwise do nothing
        }
    }
