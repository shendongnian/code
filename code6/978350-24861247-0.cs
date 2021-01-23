     [STAThread]
                public static void Main()
                {
                    SysTrayApp();
        
                    Application.Run();
                }
        
                private static NotifyIcon trayIcon;
                private static ContextMenu trayMenu;
                private static ContextMenu trayMenu2;
        
                public static void SysTrayApp()
                {
                    // Create a simple tray menu with only one item.
                    trayMenu2 = new ContextMenu();
                    trayMenu2.MenuItems.Add("Run test2", RunTest);
        
                    trayMenu = new ContextMenu();
                    trayMenu.MenuItems.Add("Run test", RunTest);
                    trayMenu.MenuItems.Add("Save-30", SaveData30).MergeMenu(trayMenu2);
                    trayMenu.MenuItems.Add("Save-80", SaveData80);
                    trayMenu.MenuItems.Add("Hide Log", HideLog);
                    trayMenu.MenuItems.Add("Show Log", ShowLog);
                    trayMenu.MenuItems.Add("Settings", OpenSettings);
                    trayMenu.MenuItems.Add("Exit", OnExit);
        
        
                    // Create a tray icon. In this example we use a
                    // standard system icon for simplicity, but you
                    // can of course use your own custom icon too.
                    trayIcon = new NotifyIcon();
                    trayIcon.Text = "MyTrayApp";
                    trayIcon.Icon = new Icon(@"C:\Users\vladimir\Downloads\Artdesigner-Emoticons-Cool.ico", 60, 60);
        
                    // Add menu to tray icon and show it.
                    trayIcon.ContextMenu = trayMenu;
                    trayIcon.Visible = true;
                }
