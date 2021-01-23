            private void button1_Click(object sender, EventArgs e)
            {
                SwitchPanel(PanelType.HomeScreen);
            }
    
            private void SwitchPanel(PanelType displayType)
            {
                foreach (var ctl in this.Controls)
                {
                    if (ctl.GetType() == typeof(CustomPanel))
                        ((CustomPanel)ctl).Visible = ((CustomPanel)ctl).PanelType == displayType;
                }
            }
