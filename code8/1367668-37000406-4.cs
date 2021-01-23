    static class WebElementExt {
        public static Bitmap TakeScreenshot(this OpenQA.Selenium.IWebElement element) {
            RemoteWebDriver driver = (RemoteWebDriver)((RemoteWebElement)element).WrappedDriver;
            if (((IHasCapabilities)driver).Capabilities.HasCapability("takesElementScreenshot")) {
                byte[] bytes = ((RemoteWebElement)element).GetScreenshot().AsByteArray;
                return (Bitmap)Bitmap.FromStream(new MemoryStream(bytes, 0, bytes.Length, false, true), false, false);
            } else {
                var dict = (Dictionary<String, Object>)driver.ExecuteScript(@"
                    arguments[0].scrollIntoView(true);
                    var r = arguments[0].getBoundingClientRect(), scrollX = 0, scrollY = 0;
                    for(var e = arguments[0]; e; e=e.parentNode) {
                      scrollX += e.scrollLeft || 0;
                      scrollY += e.scrollTop || 0;
                    }
                    return {left: r.left|0, top: r.top|0, width: r.width|0, height: r.height|0
                           , scrollX: scrollX, scrollY: scrollY, innerHeight: window.innerHeight}; "
                    , element);
                var rect = new System.Drawing.Rectangle(
                    Convert.ToInt32(dict["left"]),
                    Convert.ToInt32(dict["top"]),
                    Convert.ToInt32(dict["width"]),
                    Convert.ToInt32(dict["height"]));
                byte[] bytes = driver.GetScreenshot().AsByteArray;
                using (Bitmap bitmap = (Bitmap)Bitmap.FromStream(new MemoryStream(bytes, 0, bytes.Length, false, true), false, false)) {
                    if (bitmap.Height > Convert.ToInt32(dict["innerHeight"]))
                        rect.Offset(Convert.ToInt32(dict["scrollX"]), Convert.ToInt32(dict["scrollY"]));
                    rect.Intersect(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height));
                    if (rect.Height == 0 || rect.Width == 0)
                        throw new WebDriverException("WebElement is outside of the screenshot.");
                    return bitmap.Clone(rect, bitmap.PixelFormat);
                }
            }
        }
    }
    
