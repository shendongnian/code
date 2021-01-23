    private void InitializeLync() {
            try {
                if (this.LyncClient == null || this.LyncClient.State == ClientState.Invalid) {
                    this.LyncClient = LyncClient.GetClient();
       
                    if (this.LyncClient != null) {
                        this.LyncClient.StateChanged += this.LyncClient_StateChanged;       
                    }
                }
            } catch (Exception ex) {
                // Show message to user that Lync is not started
            }
    }
