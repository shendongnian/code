    public void WaitForAjax()
    {
      if ((bool)((IJavaScriptExecutor)WebDriver).("return window.jQuery != undefined"))
      {
        while (true)
        {
          var ajaxIsComplete = (bool)((IJavaScriptExecutor)WebDriver).ExecuteScript("return jQuery.active == 0");
          if (ajaxIsComplete)
            break;
          Thread.Sleep(100);
        }
      }
    }
