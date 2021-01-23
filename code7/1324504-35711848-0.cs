    public class MainPageViewModel : ViewModelBase
    {
        Services.SettingService.SettingService _SettingService;
        public MainPageViewModel()
        {
            _SettingService = Services.SettingService.SettingService.Instance;
        }
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            Windows.Storage.ApplicationData.Current.DataChanged += SettingsChanged;
            return Task.CompletedTask;
        }
        public override Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
        {
            Windows.Storage.ApplicationData.Current.DataChanged -= SettingsChanged;
            return Task.CompletedTask;
        }
        private void SettingsChanged(Windows.Storage.ApplicationData sender, object args)
        {
            RaisePropertyChanged(nameof(FontSize));
        }
        public double FontSize { get { return _SettingService.FontSize; } }
    }
