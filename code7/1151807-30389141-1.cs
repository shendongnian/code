    public void OnNotify()
    {
		var notify = this.Notify;
        if (notify != null)
        {
            notify();
        }
    }
