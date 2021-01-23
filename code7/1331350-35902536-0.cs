    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            // ...
        
            var m = Cirrious.CrossCore.Mvx.Resolve<IMvxMessenger>();
            GoogleAnalyticsWrapper.Initialize(m); 
            // ...
        }
    }
