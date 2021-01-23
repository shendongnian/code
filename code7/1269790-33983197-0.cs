    class Party
    {
        protected void OnMemberDeath( )
        {
            if(aliveCount > 1)
            {
                AdjustWorldObject();
                aliveCount--;
            }
            else
            {
                ResetWorldObject();
                if(OnPartyDeath != null) OnPartyDeath(); // Event
                else print( "Party died but event had no subscriptions!" );
            }
        }
        protected virtual void AdjustWorldObject()
        {
            // ...
        }
        protected virtual void ResetWorldObject()
        {
            // ...
        }
    }
    class PlayerParty : Party
    {
        protected override void AdjustWorldObject()
        {
            base.AdjustWorldObject();
            AdjustCombatUI();
        }
        protected override void ResetWorldObject()
        {
            base.ResetWorldObject();
            ResetCombatUI();
        }
    }
