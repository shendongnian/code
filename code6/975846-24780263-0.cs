    public class View1 : UserControl
    {
        ...
    }
    public class View2 : UserControl
    {
        ...
    }
    public void SwitchView(UserControl newView)
    {
        if (this.Controls.Count > 0)
        {
            this.Controls.RemoveAt(0);
        }
        this.Controls.Add(newView);
        newView.Dock = DockStyle.Fill;
    }
