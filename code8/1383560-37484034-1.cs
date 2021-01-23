    public event EventHandler<MouseEventArgs> StatusUpdate;
    public void OnStatusUpdate(MouseEventArgs e)
    {
        var handler = StatusUpdate;
        if (handler != null)
            handler(this, e);
    }
    private void UserControl1_MouseMove(object sender, MouseEventArgs e)
    {
        OnStatusUpdate(e);
    }
