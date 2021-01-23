    List<List<Match> matches = ...
    string player = "playerA";
	var coplayers =	matches.Where(x=>x.Any(p=>p.Participants.Any(s=>s.Name == player))) // get all participants where group contains participant.
               .SelectMany(x=> x.SelectMany(p=>p.Participants))                         // get all participants where group contains participant.
			   .Where(x=>x.Name != player)						                        // List co participants 
			   .GroupBy(x=>x.Name)                                                      // Distinct by grouping on Name or( need to override equal)
			   .Select(x=>x.FirstOrDefault())
			   .ToList()    
