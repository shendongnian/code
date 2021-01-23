    using Prism;
    using Prism.Ioc;
    using TestUIImage.ViewModels;
    using TestUIImage.Views;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using Prism.Autofac;
    using TestUIImage.Services;
    [assembly: XamlCompilation(XamlCompilationOptions.Compile)]
    namespace TestUIImage
    {
        public partial class App : PrismApplication
        {
        
            public App() : this(null) { }
            public App(IPlatformInitializer initializer) : base(initializer) { }
            protected override async void OnInitialized()
            {
                InitializeComponent();
                DependencyService.Register<PicturePickerImplementation>();
                await NavigationService.NavigateAsync("NavigationPage/MainPage");
            }
            protected override void RegisterTypes(IContainerRegistry    containerRegistry)
            {
                containerRegistry.RegisterForNavigation<NavigationPage>();
                containerRegistry.RegisterForNavigation<MainPage>();
            }
        }
    }
