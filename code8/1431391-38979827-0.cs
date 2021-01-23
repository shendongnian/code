    public event EventHandler<MurderEventArgs> OnMurderEvent;
    public void RaiseMurderEvent(IPerson npcVictim, IPerson npcMurderer)
    {
        if (OnMurderEvent != null)
        {
            OnMurderEvent(this, new MurderEventArgs(npcVictim, npcMurderer));
        }
    }
