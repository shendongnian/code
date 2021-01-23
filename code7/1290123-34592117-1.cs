        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings =
              new JsonSerializerSettings
          {
             DateFormatHandling = DateFormatHandling.IsoDateFormat,
             DateTimeZoneHandling = DateTimeZoneHandling.Unspecified,
             Culture = CultureInfo.GetCultureInfo("en-GB")
          };
             Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
        }
