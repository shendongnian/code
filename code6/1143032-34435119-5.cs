    public class ScreenCapture
    {
        public static Image CaptureDesktop()
        {
            // Determine the size of the "virtual screen", which includes all monitors.
            var screenLeft = SystemInformation.VirtualScreen.Left;
            var screenTop = SystemInformation.VirtualScreen.Top;
            var screenWidth = SystemInformation.VirtualScreen.Width;
            var screenHeight = SystemInformation.VirtualScreen.Height;
    
            // Create a bitmap of the appropriate size to receive the screenshot.
            var screenshot = new Bitmap(screenWidth, screenHeight);
                
            // Draw the screenshot into our bitmap.
            using (Graphics g = Graphics.FromImage(screenshot))
                g.CopyFromScreen(screenLeft, screenTop, 0, 0, screenshot.Size);
    
            return screenshot;
        }
    }
