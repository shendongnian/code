	public bool IsPresent
	{
		get 
		{
			bool isPresent = false;
			if (ViewState["IsPresent"] != null)
			{
				isPresent = (bool) ViewState["IsPresent"];
			}
			return isPresent;
		}
		set
		{
			ViewState["IsPresent"] = value;
		}
	}
