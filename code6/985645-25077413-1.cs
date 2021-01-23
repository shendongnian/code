    /* ------------------------------------------------------------------------- */
    public void connectAsync()
    {
        connectThread = new Thread(connectSync);
        connectThread.Start();
    }
