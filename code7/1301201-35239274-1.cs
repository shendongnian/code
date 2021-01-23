    using Catel.Data;
    using Catel.MVVM;
    using System.Threading.Tasks;
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            this.Connect = new Command(HandleConnectCommand);
            this.Field = new Command(HandleFieldCommand);
            this.Calibration = new Command(HandleCalibrationCommand);
            this.CurrentPage = new ConnectViewModel();
        }
        /// <summary>
        /// Gets or sets the CurrentPage value.
        /// </summary>
        public IViewModel CurrentPage
        {
            get { return GetValue<IViewModel>(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }
        /// <summary>
        /// Register the CurrentPage property so it is known in the class.
        /// </summary>
        public static readonly PropertyData CurrentPageProperty = RegisterProperty("CurrentPage", typeof(IViewModel), null);
        
        public Command Connect { get; private set; }
        public Command Field { get; private set; }
        public Command Calibration { get; private set; }
        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            // TODO: subscribe to events here
        }
        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here
            await base.CloseAsync();
        }
        private void HandleCalibrationCommand()
        {
            this.CurrentPage = new CalibrationViewModel();
        }
        private void HandleFieldCommand()
        {
            this.CurrentPage = new FieldViewModel();
        }
        private void HandleConnectCommand()
        {
            this.CurrentPage = new ConnectViewModel();
        }
    }
