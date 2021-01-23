    public event EventHandler SomeEvent;
    protected void OnSomeEvent(object sender, EventArgs e)
    {
        EventHandler eh = SomeEvent;
        if(eh != null)
        {
            eh(sender, e);
        }
    }
    
    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
        OnSomeEvent(sender, e);
    }
