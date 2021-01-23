            Queue<string> itemQueue = new Queue<string>();
            MonitorWindow monitor = new MonitorWindow(itemQueue);
           
            var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
         
            if (secondaryScreen != null)
            {
                if (!monitor.IsLoaded)
                    monitor.WindowStartupLocation = WindowStartupLocation.Manual;
                var workingArea = secondaryScreen.WorkingArea;
                monitor.Left = workingArea.Left;
                monitor.Top = workingArea.Top;
                monitor.Width = workingArea.Width;
                monitor.Height = workingArea.Height;
                // If window isn't loaded then maxmizing will result in the window displaying on the primary monitor
                monitor.Show();
                if (monitor.IsLoaded)
                    monitor.WindowState = WindowState.Maximized;
            }
