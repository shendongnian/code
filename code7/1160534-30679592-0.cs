    private void LyncClient_StateChanged(object sender, ClientStateChangedEventArgs e) {
            switch (e.NewState) {
                    case ClientState.Invalid:
                    case ClientState.ShuttingDown:					
                        this.IsLyncStarted = false;
                        this.IsLyncSignedIn = false;
                        break;
                    case ClientState.SignedOut:
                    case ClientState.SigningIn:
                    case ClientState.SigningOut  
                        this.IsLyncStarted = true;
                        this.IsLyncSignedIn = false;
                        break;
					case ClientState.SignedIn:
                        this.IsLyncStarted = true;
                        this.IsLyncSignedIn = true;
                        break;
                }
                if (!this.IsLyncStarted || !this.IsLyncSignedIn) {                    
                    // Do relevant operation
					// Show error message to user - Lync is not present
                }
        }
