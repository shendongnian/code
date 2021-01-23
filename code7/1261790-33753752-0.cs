    Q = new queue();
    Q.Show();
    Thread.Sleep( 100 ); //need to delay first before moving the position
    showOnMonitor(1, Q);
    
    public static void showOnMonitor(int monitor, Window w2)
            {
                Screen[] sc;
                sc = Screen.AllScreens;
    
                if ( monitor >= sc.Length )
                {
                    monitor = 0;
                }
    
    
                w2.WindowStartupLocation = WindowStartupLocation.Manual;
    
                var workingArea = sc[monitor].WorkingArea;
                w2.Left = workingArea.Left;
                w2.Top = workingArea.Top;
                w2.Width = workingArea.Width;
                w2.Height = workingArea.Height;
    
            }
