    private void Send()
    {
        if (this.SendResponse != null)
        {
            this.SendResponse(this, EventArgs.Empty); // <<-- pass this
        }
    }
