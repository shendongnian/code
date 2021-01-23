	private RelayCommand<IList<object>> _addMembersToEvent;
	public RelayCommand<IList<object>> AddMembersToEvent
	{
		get
		{
			return _addMembersToEvent
				   ?? (_addMembersToEvent = new RelayCommand<IList<object>>(
					   selectedMembers =>
					   {
						   List<object> membersList = selectedMembers.ToList();
					   }));
		}
	}
