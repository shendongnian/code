    public static Bitmap GetEntereScreenshot(IWebDriver driver)
            {
                Bitmap stitchedImage = null;
                try
                {
                    var jse = (IJavaScriptExecutor)driver;
                    jse.ExecuteScript("window.scrollTo(0, 0);");
    
                    var jqueryLibrary = TestExtensions.GetConfigValue("jquery_library", "");
                    var js = new JqueryExtension(driver, jqueryLibrary);
                    var driverBrowser = ((RemoteWebDriver)driver).Capabilities.BrowserName;
                    //driver_browser= 1: Internet Explorer, 2: Firefox, 3: Google Chrome
                    int totalWidth;
                    int totalHeight;
                    if (driverBrowser.Equals("internet explorer"))
                    {
                        var totalwidth1 = (Int64)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.offsetWidth;");
                        var totalHeight1 = (Int64)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.parentNode.scrollHeight;");
                        totalWidth = (int)totalwidth1;
                        totalHeight = (int)totalHeight1;
                    }
                    else
                    {
                        totalWidth = js.GetSizePage("$(document).width();");
                        totalHeight = js.GetSizePage("$(document).height();");
                    }
    
                    // Get the Size of the Viewport
                    var viewportWidth1 = js.GetSizePage("$(window).width();");
                    //var viewportHeight1 = driverBrowser == "2" ? totalHeight : js.GetSizePage("$(window).height();");
                    int viewportHeight1;
    
                    switch (driverBrowser)
                    {
                        case "internet explorer":
                            if (((RemoteWebDriver)driver).Capabilities.Version == "8" || ((RemoteWebDriver)driver).Capabilities.Version == "9")
                            {
                                viewportHeight1 = totalHeight;
                            }
                            else
                            {
                                viewportHeight1 = js.GetSizePage("$(window).height();");
                            }
                            break;
                        case "firefox":
                            viewportHeight1 = totalHeight;
                            break;
                        default:
                            viewportHeight1 = js.GetSizePage("$(window).height();");
                            break;
                    }
    
                    var viewportWidth = viewportWidth1;
                    var viewportHeight = viewportHeight1;
                    // Split the Screen in multiple Rectangles
                    var rectangles = new List<Rectangle>();
                    // Loop until the Total Height is reached
                    for (var i = 0; i < totalHeight; i += viewportHeight)
                    {
                        var newHeight = viewportHeight;
                        
                        // Fix if the Height of the Element is too big
                        if (i + viewportHeight > totalHeight)
                        {
                            newHeight = totalHeight - i;
                        }
                        // Loop until the Total Width is reached
                        for (var ii = 0; ii < totalWidth; ii += viewportWidth)
                        {
                            var newWidth = viewportWidth;
                            // Fix if the Width of the Element is too big
                            if (ii + viewportWidth > totalWidth)
                            {
                                newWidth = totalWidth - ii;
                            }
    
                            // Create and add the Rectangle
                            var currRect = new Rectangle(ii, i, newWidth, newHeight);
                            rectangles.Add(currRect);
                        }
                    }
                    // Build the Image
                    stitchedImage = new Bitmap(totalWidth, totalHeight);
                    // Get all Screenshots and stitch them together
                    var previous = Rectangle.Empty;
                    foreach (var rectangle in rectangles)
                    {
                        // Calculate the Scrolling (if needed)
                        if (previous != Rectangle.Empty)
                        {
                            var xDiff = rectangle.Right - previous.Right;
                            var yDiff = previous.Height;//rectangle.Bottom - previous.Bottom;
                           ((IJavaScriptExecutor)driver).ExecuteScript(String.Format("window.scrollBy({0}, {1})", xDiff, yDiff));
                         
                            System.Threading.Thread.Sleep(500);
                        }
    
                        // Take Screenshot
                        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
    
                        // Build an Image out of the Screenshot
                        Image screenshotImage;
                        using (var memStream = new MemoryStream(screenshot.AsByteArray))
                        {
                            screenshotImage = Image.FromStream(memStream);
                        }
    
                        // Calculate the Source Rectangle  
                        var sourceRectangle = new Rectangle(viewportWidth - rectangle.Width, viewportHeight - rectangle.Height, rectangle.Width, rectangle.Height);
                        
                        // Copy the Image
                        using (var g = Graphics.FromImage(stitchedImage))
                        {
                            g.DrawImage(screenshotImage, rectangle, sourceRectangle, GraphicsUnit.Pixel);
                        }
                        // Set the Previous Rectangle
                        previous = rectangle;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return stitchedImage;
            }
