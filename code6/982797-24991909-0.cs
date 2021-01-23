        private void sharedButton_Click(object sender, EventArgs e)
        {
            buttonFunction(((Button)sender).Tag.ToString());
        }
        private void buttonFunction(string formName)
        {
            Form frm = Application.OpenForms[formName] as Form;
            if (frm != null)
            {
                frm.WindowState = FormWindowState.Maximized;
                frm.BringToFront();
                frm.Activate();
            }
            else
            {
                // Open right form according to formName
                Type CAType = Type.GetType("yournamespacehere." + formName);
                frm = (Form)Activator.CreateInstance(CAType);
                frm.MdiParent = this;
                if (rbnMain.OrbDropDown.RecentItems.All(item => item.Text != frm.Text))
                {
                    var rbtn = new RibbonButton { Text = frm.Text, DrawIconsBar = false, MaxSizeMode = RibbonElementSizeMode.Medium, SmallImage = Properties.Resources.preview_24x24 };
                    rbtn.Click += (s, ea) =>
                    {
                        var frmv = Application.OpenForms["frmVPNManager"] as Form;
                        if (frmv != null)
                        {
                            frmv.WindowState = FormWindowState.Maximized;
                            frmv.BringToFront();
                            frmv.Activate();
                        }
                        else
                        {
                            rbnMain.OrbDropDown.RecentItems.RemoveAll(item => item.Text == frm.Text);
                        }
                    };
                    rbnMain.OrbDropDown.RecentItems.Add(rbtn);
                }
                frm.Show();
                frm.BringToFront();
                frm.WindowState = FormWindowState.Maximized;
            }
        }
