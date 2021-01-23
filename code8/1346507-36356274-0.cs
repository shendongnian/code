    public static void SwitchToPopup(TestTarget target, bool toPopup)
    {
        if (target.IsOpera)
        {
            if (toPopup)
            {
                _windowIndex += 3;
                new WebDriverWait(target.Driver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds)).Until(d => d.WindowHandles.Count > _windowIndex);
            }
            else
            {
                _windowIndex -= 3;
            }
            target.Driver.SwitchTo().Window(target.Driver.WindowHandles[_windowIndex]);
        }
        else
        {
            IEnumerable<string> windowHandles = toPopup ? target.Driver.WindowHandles : target.Driver.WindowHandles.Reverse();
    
            bool bFound = false;
            foreach (string windowHandle in windowHandles)
            {
                if (bFound)
                {
                    target.Driver.SwitchTo().Window(windowHandle);
                    break;
                }
                bFound = windowHandle == target.Driver.CurrentWindowHandle;
            }
        }
    }
