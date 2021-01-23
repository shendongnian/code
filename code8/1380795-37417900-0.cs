        /// <summary>
        /// Allows for events to be posted back to the user from the browser
        /// </summary>
        /// <param name="wd">The WebDriver to hook into</param>
        /// <param name="Error">Any Exceptions if thrown</param>
        /// <param name="Navigating">On Navigation start</param>
        /// <param name="NavigatedToURL">On Navigation complete</param>
        /// <param name="Clicked">On web element clicked</param>
        /// <param name="HookedDriver">The Hooked driver</param>
        /// <returns>The Hooked driver</returns>
        public static IWebDriver HookEventFiringWebDriver(this IWebDriver wd,
            Action<WebDriverExceptionEventArgs> Error = null,
            Action<WebDriverNavigationEventArgs> Navigating = null,
            Action<WebDriverNavigationEventArgs> NavigatedToURL = null,
            Action<WebElementEventArgs> Clicked = null,
            Action<IWebDriver> HookedDriver = null)
        {
            var ed = new EventFiringWebDriver(wd);
            ed.ElementClicked += new EventHandler<WebElementEventArgs>((o, ea) =>
            {
                if (Clicked != null) Clicked(ea);
            });
            ed.Navigated += (driver, ea) =>
            {
                if (NavigatedToURL != null) NavigatedToURL(ea);
            };
            ed.Navigating += (driver, ea) =>
            {
                if (NavigatedToURL != null) NavigatedToURL(ea);
            };
            ed.ExceptionThrown += (driver, ea) =>
            {
                if (Error != null) Error(ea);
            };
            if (HookedDriver != null) HookedDriver(ed);
            return ed;
        }
