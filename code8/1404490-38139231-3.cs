    public static void SortByAny(List<Person> listToSort, String sortBy)
    {
		if (sortBy == "Email")
			listToSort.Sort((x, y) => x.Email.CompareTo(y.Email));
		else if (sortBy == "Phone")
			listToSort.Sort((x, y) => x.Phone.CompareTo(y.Phone));
		else if (sortBy == "Age")
			listToSort.Sort((x, y) => x.Age.CompareTo(y.Age));
		else if (sortBy == "Id.NiNumber")
			listToSort.Sort((x, y) => x.Id.NiNumber.CompareTo(y.Id.NiNumber));
		else if (sortBy == "Id.Name.FirstName")
			listToSort.Sort((x, y) => x.Id.Name.FirstName.CompareTo(y.Id.Name.FirstName));
		else if (sortBy == "Id.Name.LastName")
			listToSort.Sort((x, y) => x.Id.Name.LastName.CompareTo(y.Id.Name.LastName));
	}
