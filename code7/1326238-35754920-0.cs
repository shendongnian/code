    public void PollUpdate()
            {
                while (true)
                {
                    if (reload)
                    {
                        stopwatch.Stop();
                        reload = false;
                        SuspendLayout();
                        Control ctrl = Parent.Parent.Controls.Find("MainControlPanel", false).First();
                        AudioLibraryControl cr = new AudioLibraryControl();
                        cr.Dock = DockStyle.Fill;
                        Parent.Controls.Remove(this);
                        ctrl.Controls.Add(cr);
                        ResumeLayout();
                    }
                    Application.DoEvents();
    
                }
            }
