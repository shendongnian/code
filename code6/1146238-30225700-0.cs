    public Form1()
    {
        updateStuff = new System.Timers.Timer();
        updateStuff.SynchronizingObject = this;
        ...
    }
    public void setText(string text)
    {
        lblTest.Text = text;
    }
