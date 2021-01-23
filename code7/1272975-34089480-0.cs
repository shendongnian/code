	[Given(@"I add the following users")]
    public void GivenIAddTheFollowingUsers(IEnumerable<dynamic> people)
    {
        foreach(var person in people)
        {
			var header = new [] {"FirstName", "Surname", "Age"};
			var personTable = new Table(header);
			personTable.AddRow(person.FirstName, person.Surname, person.Age);
		
            When(@"I go to the add person page");
            Then(@"I enter the details of the person", personTable);
			When(@"I save the new person");
			Then(@"I am taken back to the view people page");
        }
    }
