        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            InitializeCultures();
        }
        private static void InitializeCultures()
        {
            var culture = ConfigurationManager.AppSettings.Get("Culture");
            if (!String.IsNullOrEmpty(culture))
            {
                Thread.CurrentThread.CurrentCulture =  new CultureInfo(culture);
            }
            var UICulture = ConfigurationManager.AppSettings.Get("UICulture");
            if (!String.IsNullOrEmpty(UICulture))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(UICulture);
            }
        }
