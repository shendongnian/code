	private static void ForWithVariable(IEnumerable<Person> clients)
	{
		Func<Person, bool> arg_21_1;
		if ((arg_21_1 = Program.<>c.<>9__1_0) == null)
		{
			arg_21_1 = (Program.<>c.<>9__1_0 = new Func<Person, bool>(Program.<>c.<>9.<ForWithVariable>b__1_0));
		}
		IEnumerable<Person> enumerable = clients.Where(arg_21_1);
		foreach (Person current in enumerable)
		{
			Console.WriteLine(current.Age.ToString());
		}
	}
	private static void ForWithoutVariable(IEnumerable<Person> clients)
	{
		Func<Person, bool> arg_22_1;
		if ((arg_22_1 = Program.<>c.<>9__2_0) == null)
		{
			arg_22_1 = (Program.<>c.<>9__2_0 = new Func<Person, bool>(Program.<>c.<>9.<ForWithoutVariable>b__2_0));
		}
		foreach (Person current in clients.Where(arg_22_1))
		{
			Console.WriteLine(current.Age.ToString());
		}
	}
