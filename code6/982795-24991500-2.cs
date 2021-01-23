    // This is the overload that uses default name for your form generated using the Type name
    private void formtest<T>() 
        where T : Form, new
    {
        formtest<T>(typeof(T).Name); // assume that type of the form is the name of the form instance.
    }
    
    // Here we use first overload that uses default name for the form
    private void rbtnVPNList_Click(object sender, EventArgs e)
    {
        formtest<frmVPNList>();
    }
    
    
    // This is your original code with generic restrictions. Here you can specify name for the form that differs from its type name.
    private void formtest<T>(String formname) 
        where T : Form, new
    {
        if (Application.OpenForms[formname] != null)
        {
            var frm = Application.OpenForms[formname];
            if (frm is T)
            {
                frm.WindowState = FormWindowState.Maximized;
                frm.BringToFront();
                frm.Activate();
            }
        }
        else
        {
            var frm = new T() { MdiParent = this };
        if (rbnMain.OrbDropDown.RecentItems.All(item => item.Text != frm.Text))
        {
            var rbtn = new RibbonButton { Text = frm.Text, DrawIconsBar = false, MaxSizeMode = RibbonElementSizeMode.Medium, SmallImage = Properties.Resources.preview_24x24 };
            rbtn.Click += (s, ea) =>
            {
                var frmv = Application.OpenForms[formname] as T;
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
