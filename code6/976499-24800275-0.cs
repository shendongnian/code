        Vlc.DotNet.Forms.VlcControl vlcControl;
        Vlc.DotNet.Core.Medias.PathMedia Media2Play;
        public void PlayMedia(string fileName)
        {
            if (Vlc.DotNet.Core.VlcContext.IsInitialized == false)
                initVLC();
            //StopVLC();
            //Panel1: "panelVideo" holds "Vlc.DotNet.Forms.VlcControl"
            //Panel2: "panelDoubleClick" created  at runtime and "vlcControl.Controls.Add(panelDoubleClick);" 
            //Panel2: panelDoubleClick.BackColor = Color.Transparent;
            //panelDoubleClick.MouseDoubleClick += panelDoubleClick_MouseDoubleClick;
            vlcControl = new Vlc.DotNet.Forms.VlcControl();
            vlcControl.CreateControl();
            vlcControl.Dock = DockStyle.Fill;
            this.panelVideo.Controls.Add(vlcControl);//panelVideo is manin container panel.
            //initEvents();//VLC player events
            Panel panelDoubleClick = new Panel();// this panel requires to catche double click evetns.
            panelDoubleClick.Dock = DockStyle.Fill;
            panelDoubleClick.BackColor = Color.Transparent;
            panelDoubleClick.MouseDoubleClick += new MouseEventHandler(panelDoubleClick_MouseDoubleClick); ;
            if (vlcControl != null)
            {
                Media2Play = new Vlc.DotNet.Core.Medias.PathMedia(fileName);
                vlcControl.Media = Media2Play;
                vlcControl.Show();
                vlcControl.Play();
                vlcControl.Controls.Add(panelDoubleClick);
                panelDoubleClick.BringToFront();
            }
        }
        private void panelDoubleClick_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           MessageBox.Show  ("ToggleFullScreen();");
        }
        private void initVLC()
        {
            try
            {
                // Set libvlc.dll and libvlccore.dll directory path
                string vlcPath = "";
                
                vlcPath = "E:\\VLC\\VLC_minimal";
                if (System.IO.Directory.Exists(vlcPath) == false)
                {
                    vlcPath = Application.StartupPath.Trim('\\') + "\\VLC\\";
                    if (System.IO.Directory.Exists(vlcPath) == false)
                    {
                        if (Environment.Is64BitOperatingSystem)
                        {
                            vlcPath = "C:\\Program Files (x86)\\VideoLAN\\VLC";
                        }
                        else
                        {
                            vlcPath = "C:\\Program Files\\VideoLAN\\VLC";
                        }
                        if (System.IO.Directory.Exists(vlcPath) == false)
                        {
                            MessageBox.Show("VLC cannot be fount on your system.");
                            Application.Exit();
                            return;
                        }
                    }
                }
                Vlc.DotNet.Core.VlcContext.LibVlcDllsPath = vlcPath;
                // CommonStrings.LIBVLC_DLLS_PATH_DEFAULT_VALUE_AMD64;
                // Set the vlc plugins directory path
                Vlc.DotNet.Core.VlcContext.LibVlcPluginsPath = Vlc.DotNet.Core.VlcContext.LibVlcDllsPath + "\\pugins";
                //CommonStrings.PLUGINS_PATH_DEFAULT_VALUE_AMD64;
                // Ignore the VLC configuration file
                Vlc.DotNet.Core.VlcContext.StartupOptions.IgnoreConfig = true;
                // Enable file based logging
                Vlc.DotNet.Core.VlcContext.StartupOptions.LogOptions.LogInFile = false;
                // Shows the VLC log console (in addition to the applications window)
                Vlc.DotNet.Core.VlcContext.StartupOptions.LogOptions.ShowLoggerConsole = false;
                // Set the log level for the VLC instance
                Vlc.DotNet.Core.VlcContext.StartupOptions.LogOptions.Verbosity = Vlc.DotNet.Core.VlcLogVerbosities.None;
                Vlc.DotNet.Core.VlcContext.StartupOptions.ScreenSaverEnabled = false;
                Vlc.DotNet.Core.VlcContext.StartupOptions.AddOption("--no-video-title");
                //hide played media filename on startingto play media.
                
                // Initialize the VlcContext
                Vlc.DotNet.Core.VlcContext.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
