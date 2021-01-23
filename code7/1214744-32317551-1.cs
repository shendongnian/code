	@if(Model.Condition)
	{
		@using (Ajax.BeginForm(...))
		{
			@Html.EditorForModel()
		}
	}
	else
	{
		@using (Html.BeginForm(...))
		{
			@Html.EditorForModel()
		}
	}
