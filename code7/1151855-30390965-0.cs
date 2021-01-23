    bool hasChange = false;
	public bool HasChange
	{
		get { return hasChange; }
		set	{ hasChange = value; }
	}
	private void Control_SourceUpdated(object sender, DataTransferEventArgs e)
	{
		this.HasChange = true;
	}
