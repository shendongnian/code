      /// <summary>
      /// Set the theme toggle to the correct position (off for the default theme, and on for the non-default).
      /// </summary>
      private void SetThemeToggle(ElementTheme theme)
      {
         if (theme == AppSettings.DEFAULTTHEME)
            tglAppTheme.IsOn = false;
         else
            tglAppTheme.IsOn = true;
      }
