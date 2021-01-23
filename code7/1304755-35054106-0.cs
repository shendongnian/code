    private void FixedUpdate()
    {
    ...
    
        U.Events.OnPlayerDisconnected += (UnturnedPlayer player) =>
        {
        };
    }
    public int indexHolder(int i)
    {
        return i;
    }
    public void playerTimeVars(object source, ElapsedEventArgs e)
    {     
        int localIndex = indexHolder(index);
        playerTimer[localIndex] = 0;
    }
    
