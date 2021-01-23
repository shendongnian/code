    public class MainPageViewModel : ViewModelBase
    {
        Services.SettingService.SettingService _SettingService;
        public MainPageViewModel()
        {
            _SettingService = Services.SettingService.SettingService.Instance;
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            Windows.Storage.ApplicationData.Current.DataChanged += SettingsChanged;
            await Task.CompletedTask;
        }
        public override async Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
        {
            Windows.Storage.ApplicationData.Current.DataChanged -= SettingsChanged;
            await Task.CompletedTask;
        }
        private void SettingsChanged(Windows.Storage.ApplicationData sender, object args)
        {
            RaisePropertyChanged(nameof(FontSize));
        }
        public double FontSize { get { return _SettingService.FontSize; } }
    }
