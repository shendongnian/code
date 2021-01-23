    // Capabilities Values
    var imageSetting = new Dictionary<string, object> {{"images", 2}};
    var content =      new Dictionary<string, object> {{"profile.default_content_settings", imageSetting}};
    var prefs =        new Dictionary<string, object> {{"prefs", content}};
    // List of Chromium Command Line Switches 
    var options = new ChromeOptions(); 
    options.AddArguments( 
         "--disable-extensions", 
         "--disable-features", 
         "--disable-popup-blocking",
         "--disable-settings-window");
    // Add the Capabilities
    var field = options.GetType().GetField("additionalCapabilities", BindingFlags.Instance | BindingFlags.NonPublic);
    if (field != null)
    {
         var dict = field.GetValue(options) as IDictionary<string, object>;
         if (dict != null) dict.Add(ChromeOptions.Capability, prefs);
    }
    // Create the Chrome Driver
    var chromeDriver = new ChromeDriver(options);
