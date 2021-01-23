    return dbConnection
		.Query<Owner, Pet, Owner>(
			query,
			(owner, pet) =>
			{
				owner.Pets = owner.Pets ?? new List<Pet>();
				owner.Pets.Add(pet);
				return owner;
			},
			new { Status = status },
			splitOn: "Name"
		)
		.GroupBy(o => o.Id)
		.Select(group =>
		{
			var combinedOwner = group.First();
			combinedOwner.Pets = group.Select(owner => owner.Pets.Single()).ToList();
			return combinedOwner;
		});
