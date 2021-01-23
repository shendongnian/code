     FontDialog fd = new FontDialog();
                fd.ShowDialog();
                Settings.Default.MyFont = fd.Font;
                Settings.Default.Save();
                Font = Settings.Default.MyFont;
                foreach (Control c in Controls)
                {
                    c.Font = Settings.Default.MyFont;
                }
