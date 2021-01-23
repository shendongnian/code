    if (speech == "initiate power saving mode")
            {
                Taskbar taskbar = new Taskbar();
                taskbar.Show();
                SoundPlayer deacr = new SoundPlayer(Properties.Resources.deacr);
                deacr.PlaySync();
                else if (speech== "confirm")
                {
                    SoundPlayer deacd = new SoundPlayer(Properties.Resources.deacd);
                    deacd.PlaySync();
                    Application.SetSuspendState(PowerState.Suspend, true, true);
                }
                else if (speech == "cancel")
                {
                    SoundPlayer cancelled = new SoundPlayer(Properties.Resources.cancelled);
                    cancelled.PlaySync();                    
                }
            }
