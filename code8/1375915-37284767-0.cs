    private void btnShutdown_Click(object sender, EventArgs e)
            {
                //Shutdown the highligted systems 
                List<Control> list = new List<Control>();
                GetAllControl(this, list);
                DoShutdown(list);
            }
    
            private void btnRestart_Click(object sender, EventArgs e)
            {
                //Restart the highighted systems
                List<Control> list = new List<Control>();
                GetAllControl(this, list);
                DoRestart(list);
            }
    
            private void DoRestart(List<Control> list)
            {
                foreach (Control control in list)
                {
                    if (control.BackColor == System.Drawing.Color.Aqua)
                    {
                        restart m = new restart();
                        m.restartwin(control.Text);
                        
                    }
                }
                MessageBox.Show("Restart sent!", "Restart", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
    
            private void DoShutdown(List<Control> list)
            {
                foreach (Control control in list)
                {
                    if (control.BackColor == System.Drawing.Color.Aqua)
                    {
                        powerApp m = new powerApp();
                        m.poweroffwin(control.Text);
                        
                    }
                }
                MessageBox.Show("Shutdown sent!", "Shutdown", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
    
    
            private void GetAllControl(Control c, List<Control> list)
            {
                foreach (Control control in c.Controls)
                {
                    list.Add(control);
    
                    if (control.Controls.Count > 0)
                    {
                        GetAllControl(control, list);
                    }
    
                }
            }
