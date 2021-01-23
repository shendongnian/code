    class AppSettings
    {
       public const ElementTheme DEFAULTTHEME = ElementTheme.Light;
       public const ElementTheme NONDEFLTHEME = ElementTheme.Dark;
       const string KEY_THEME = "appColourMode";
       static ApplicationDataContainer LOCALSETTINGS = ApplicationData.Current.LocalSettings;
       /// <summary>
       /// Gets or sets the current app colour setting from memory (light or dark mode).
       /// </summary>
       public static ElementTheme Theme {
          get {
             // Never set: default theme
             if (LOCALSETTINGS.Values[KEY_THEME] == null)
             {
                LOCALSETTINGS.Values[KEY_THEME] = (int)DEFAULTTHEME;
                return DEFAULTTHEME;
             }
             // Previously set to default theme
             else if ((int)LOCALSETTINGS.Values[KEY_THEME] == (int)DEFAULTTHEME)
                return DEFAULTTHEME;
             // Previously set to non-default theme
             else
                return NONDEFLTHEME;
          }
          set {
             // Error check
             if (value == ElementTheme.Default)
                throw new System.Exception("Only set the theme to light or dark mode!");
             // Never set
             else if (LOCALSETTINGS.Values[KEY_THEME] == null)
                LOCALSETTINGS.Values[KEY_THEME] = (int)value;
             // No change
             else if ((int)value == (int)LOCALSETTINGS.Values[KEY_THEME])
                return;
             // Change
             else
                LOCALSETTINGS.Values[KEY_THEME] = (int)value;
          }
       }
    }
