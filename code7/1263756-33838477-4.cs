    public sealed partial class App
    {
      private WinRTContainer _container;
        
      protected override void Configure()
      {
         _container = new WinRTContainer();
         _container.RegisterWinRTServices();
         _container
              .PerRequest<ShellViewModel>()
              .PerRequest<MyFirstViewModel>()
              .PerRequest<MySecondViewModel>()
              .PerRequest<MyThirdViewModel>()
              .PerRequest<MainViewModel>();
         var navigationManager = SystemNavigationManager.GetForCurrentView();
         navigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
         
      }
    }
