   	sessionPlanner = new SessionPlannerDTO
	{
		Age = "",
		// ...
		PracticeView = session.Sessions.Select(s =>
			new PracticeViewDTO
			{
				AbilityLevel = s.ActivityPlan.abilityLevel.Value,
				// ...
			}).ToList()
	};
