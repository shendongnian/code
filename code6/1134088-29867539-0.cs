		var personOneList = new List<PersonOne>();
		var personTwoList = new List<PersonTwo>();
		var personOnePersonTwoList = new List<PersonOnePersonTwo>();
		foreach (var personOne in personOneList)
		{
			personOnePersonTwoList = personTwoList.Where(x => x.firstname.Equals(personOne.name, StringComparison.OrdinalIgnoreCase) && 
															  x.lastname.Equals(personOne.surname, StringComparison.OrdinalIgnoreCase))
												  .Select(x => new PersonOnePersonTwo {PersonOneId = personOne.id, PersonTwoId = x.id}).ToList();
		};
