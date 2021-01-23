    private void tabControl1_Selected(object sender, TabControlEventArgs e)
    {
        ListView listView = this.FindListView(e.TabPage.Controls);
    }
    private ListView FindListView(Control.ControlCollection controls)
    {
        ListView result = null;
        foreach (Control control in controls)
        {
            result = control as ListView;
            if (result == null)
            {
                result = FindListView(control.Controls);
            }
            if (result != null)
            {
                break;
            }
        }
        return result;
    }
