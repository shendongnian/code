	List<Person> personList =
		new string[] { "Andy", "Betty" }
			.Select(n => new Person(n))
			.ToList();
	foreach (Person person in personList)
	{
		Console.WriteLine(person.Name);
	}
	Person aPerson = personList.First(p => p.Name == "Andy");
	aPerson.Name = "Charlie";
	List<Func<string>> nameList =
		personList
			.Select(p => (Func<string>)(() => p.Name))
			.ToList();
	foreach (Func<string> f in nameList)
	{
		Console.WriteLine(f());
	}
