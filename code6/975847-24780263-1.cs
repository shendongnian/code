    public class StartView : UserControl
    {
        ...
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Raise a separate event upon the button being clicked
            if (StartButtonPressed != null)
                StartButtonPressed(this, EventArgs.Empty);
        }
        public event EventHandler<EventArgs> StartButtonPressed;
    }
    public class GameView : UserControl
    {
        ...
    }
    public UserControl SwitchView(UserControl newView)
    {
        UserControl oldControl = null;
        if (this.Controls.Count > 0)
        {   oldControl = (UserControl)this.Controls[0];
            this.Controls.RemoveAt(0);
        }
        this.Controls.Add(newView);
        newView.Dock = DockStyle.Fill;
        return oldControl;
    }
