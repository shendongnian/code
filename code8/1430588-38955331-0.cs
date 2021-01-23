        using System.Linq;
        using System.Windows;
    
        namespace ExtendedControls
    
    {
        static public class WindowExt
        {
    
            // NB : Best to call this function from the windows Loaded event or after showing the window
            // (otherwise window is just positioned to fill the secondary monitor rather than being maximised).
            public static void MaximizeToSecondaryMonitor(this Window window)
            {
                var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
    
                if (secondaryScreen != null)
                {
                    if (!window.IsLoaded)
                        window.WindowStartupLocation = WindowStartupLocation.Manual;
    
                    var workingArea = secondaryScreen.WorkingArea;
                    window.Left = workingArea.Left;
                    window.Top = workingArea.Top;
                    window.Width = workingArea.Width;
                    window.Height = workingArea.Height;
                    // If window isn't loaded then maxmizing will result in the window displaying on the primary monitor
                    if ( window.IsLoaded )
                        window.WindowState = WindowState.Maximized;
                }
            }
        }
    }
