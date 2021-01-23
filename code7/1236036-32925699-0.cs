	List<CV_details> deleteList = new List<CV_details>();
	foreach (var person in list){
		if (person.getID()==id)
		{
			//...
			n = Int32.Parse(Console.ReadLine());
			if (n == 1)
			{
				deleteList.Add(person);
			}
		}
	}
	foreach (var del in deleteList)
	{
		list.Remove(del);
	}
