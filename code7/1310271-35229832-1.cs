	var query =
	db.Directors.GroupJoin(db.Managers, director => director.DirectorId, manager => manager.DirectorId, (director, managerGroup) => new
	{
		Id = director.DirectorID,
		Name = director.DirectorName,
		Managers = managerGroup.GroupJoin(db.Leaders, manager => manager.ManagerId, leader => leader.ManagerID, (manager, leaderGroup) => new
		{
			Id = manager.ManagerID,
			Name = manager.ManagerName,
			Leaders = leaderGroup.Select(leader => new
			{
				Id = leader.LeaderID,
				Name = leader.LeaderName
			})
		})
	})
	.SelectMany(director =>  
		new[] { new
		{
			DirID = director.Id, DirectorName = director.Name,
			MgrID = (int?)null, ManagerName = (string)null,
			LdrID = (int?)null, LeaderName = (string)null
		} }
		.Concat(director.Managers.SelectMany(manager => 
			new[] { new
			{
				DirID = director.Id, DirectorName = director.Name,
				MgrID = (int?)manager.Id, ManagerName = manager.Name,
				LdrID = (int?)null, LeaderName = (string)null
			} }
			.Concat(manager.Leaders.Select(leader => new
			{
				DirID = director.Id, DirectorName = director.Name,
				MgrID = (int?)manager.Id, ManagerName = manager.Name,
				LdrID = (int?)leader.Id, LeaderName = leader.Name
			}))
		))
	);
