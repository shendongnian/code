      try
                {
                    string cultureName = "en-GB";
                    var locale = new Java.Util.Locale(cultureName);
                    Java.Util.Locale.Default = locale;
    
                    var configg = new Android.Content.Res.Configuration { Locale = locale };
                    BaseContext.Resources.UpdateConfiguration(configg, BaseContext.Resources.DisplayMetrics);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
               
                }
