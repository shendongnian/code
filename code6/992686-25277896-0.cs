    var picks = context.Picks.Where(p => ((p.Game.SeasonID == seasonID) && (p.Game.Week == week) && (p.PoolID == poolID) && (p.UserID == userID)))
    	.Select(p => new
    	{
    		Pick = p,
    		Game = p.Game,
    		HomeTeam = p.Game.HomeTeam,
    		VisitingTeam = p.Game.VisitingTeam,
    		HomeTeamRecords = p.Game.HomeTeam.TeamRecords.Where(tr => tr.SeasonID == seasonID),
    		VisitingTeamRecords = p.Game.VisitingTeam.TeamRecords.Where(tr => tr.SeasonID == seasonID),
    		Pool = p.Pool
    	})
    	.ToArray().Select(p => p.Pick).ToArray();
