    private EventHandler _timerElapsedHandler;
    // Subscribed to the MouseEnter event
    private void keysHover(object sender, EventArgs e)
    {
        _timerElapsedHandler = delegate { keysHoverOK(sender); };
        myTimer.Elapsed += _timerElapsedHandler;
        myTimer.Enabled = true;
    }
    // Subscribed to the MouseLeave event
    private void keysLeave(object sender, EventArgs e)
    {
        DisableTimer();
    }
    private void keysHoverOK(object sender)
    {
        this.Dispatcher.Invoke((Action)(() =>
        {
            txtTest.Text += (sender as System.Windows.Controls.Button).Content.ToString();
        }));
        DisableTimer();
    }
    private void DisableTimer()
    {
        myTimer.Elapsed -= _timerElapsedHandler;
        myTimer.Enabled = false;
        _timerElapsedHandler = null;
    }
