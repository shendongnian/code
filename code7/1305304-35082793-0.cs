        public ActionResult Index()
        {
            // The Index is the only page that does not respond to the LocalizedViewEngine as it should...
            var currentCulture = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            if (currentCulture != LocalizationAttribute.DefaultCulture)
                return View(string.Format("Index.{0}", currentCulture));
            else
                return View();
        }
