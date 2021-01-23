    var enums = Enum.GetValues(typeof(SomeAction)).Cast<SomeAction>();
    for (int i = 0; i < list.Count; i++)
    {
    	if (list.ElementAt(i).Action != (SomeAction)i)
    	{
    		return false;
    	}
    }
    return true;
