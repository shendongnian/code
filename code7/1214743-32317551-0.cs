	@{
		IDisposable form;
		
		if(Model.Condition)
		{
			form = Ajax.BeginForm(...);    
		}
		else
		{
			form = Html.BeginForm(...);
		}
    }
	using (form)
	{
		// Form here
	}
