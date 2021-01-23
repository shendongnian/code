    TabPage tab = new TabPage();
    [...]
    int j = 0;
    foreach (Control ctl in tab.Controls)
    {
        Debug.WriteLine(j + " - " + ctl.Name + " - " + ctl.Text);
        tab2.Controls.Add(ctl);
        j++;
    }
