    private void alphaClicked()
    {
       if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
            //do something
        }
       else
       {
           Connect("alpha");
       }
    }
    private void betaClicked()
    {
       if(GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED) {
            //do something else
        }
       else
       {
           Connect("beta");
       }
    }
