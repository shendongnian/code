    public static class SwitchExtensions
    {
        public static IAlert AlertOrNull(this ITargetLocator locator)
        {
            try
            {
                return locator.Alert();
            }
            catch (NoAlertPresentException)
            {
                return null;
            }
        }
    }
