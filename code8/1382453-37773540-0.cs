    public class MainPageViewModel : ViewModelBase
    {
        ISettingsService _setting;
        public MainPageViewModel(ISettingsService setting)
        {
           _setting = setting;
        }
     }
    [Bindable]
    sealed partial class App : Template10.Common.BootStrapper
    {
        internal static ServiceContainer Container;
        public App()
        {
            InitializeComponent();
        }
        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            if(Container == null)
                Container = new ServiceContainer();
            Container.Register<INavigable, MainPageViewModel>(typeof(MainPage).FullName);
            Container.Register<ISettingsService, RoamingSettingsService>();
            // other initialization code here
            await Task.CompletedTask;
        }
        public override INavigable ResolveForPage(Page page, NavigationService navigationService)
        {
            return Container.GetInstance<INavigable>(page.GetType().FullName);
        }
    }
    
 
