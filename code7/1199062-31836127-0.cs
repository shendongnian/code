    newForm.TopLevel = false;
    newForm.ControlBox = false;
    newForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
    newForm.Dock = DockStyle.Fill;
    var newTab = new TabPage()
    newTab.Controls.Add(newForm);
    this.MainTabControl.TabPages.Add(newTab);
    this.MainTabControl.SelectedTab = newTab;
    newForm.Show();
