    Player me = new Player { Name = "Me" };
	var allMatches = new List<Match>
	{
		new Match
		{
			Participants = new List<Player> 
			{
				me,
				new Player { Name = "Some Other Dude"}
			}
		},
		
		new Match
		{
			Participants = new List<Player>
			{
				me,
				new Player { Name = "My Rival" }
			}
		}
	};
	
	var myMatches = allMatches.Where(m => m.Participants.Contains(me)).ToList();
	var myOpponents = myMatches.SelectMany(m => m.Participants.Except(new [] {me})).Distinct();
