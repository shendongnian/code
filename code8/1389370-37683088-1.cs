    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            var cefSettings = new CefSettings();
            cefSettings.SetOffScreenRenderingBestPerformanceArgs();
            Cef.Initialize(cefSettings);
        }
    }
