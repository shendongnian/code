    var enums = Enum.GetValues(typeof(SomeAction)).Cast<SomeAction>();
    for (int i = 0; i < list.Count; i++)
    {
    	var listAction = list.ElementAt(i).Action;
    	var indexEnumAction = (SomeAction)i;
    	Console.WriteLine("{0} == {1} ? {2}", listAction, indexEnumAction, listAction == indexEnumAction);
    }
