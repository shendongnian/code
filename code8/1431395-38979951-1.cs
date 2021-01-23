	class EventRaiser<TVictim, TMurderer>
	{
	    public event EventHandler<MurderEventArgs<TVictim, TMurderer>> OnMurderEvent;
	
	    public void RaiseMurderEvent(TVictim npcVictim, TMurderer npcMurderer)
	    {
	        if (OnMurderEvent != null)
	        {
	            OnMurderEvent(this, new MurderEventArgs<TVictim, TMurderer>(npcVictim, npcMurderer));
	        }
	    }
	}
