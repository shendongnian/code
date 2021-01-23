    public static bool IsDebug(this HtmlHelper htmlHelper)
        {
    #if DEBUG
          return true;
    #else
          return false;
    #endif
        }
