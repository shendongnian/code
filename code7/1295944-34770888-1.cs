    m.MenuItems.Add(new MenuItem("New", MenuItemNew_Click));
    ...
    private void MenuItemNew_Click(Object sender, System.EventArgs e)
    {
        new FrmInfo().ShowDialog();
    }
