	public Asset.Members.DataMembers DoNothing()
	{
		var dataMember = new Asset.Members.DataMembers();
		// Pass values to datamember
		dataMember.SetValues("ValueA", "ValueB");
		
		// Return values to the caller
		return dataMember;
	}
