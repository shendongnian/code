    public void SomeEventHandler(someparameters)
    {
        if (InvokeRequired)
            Invoke((Action)(() => SomeEventHandler(someparameters))); // invoke itself
        else
        {
            ... // put code which should run in UI thread here
        }
    }
