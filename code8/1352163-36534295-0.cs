	var newList = ListB.Union(ListA, new PersonEqualityComparer());
	class PersonEqualityComparer : IEqualityComparer<Person>
	{
		public bool Equals(Person person1, Person person2)
		{
			if (person1 == null && person2 == null)
				return true;
			else if ((person1 != null && person2 == null) ||
					(person1 == null && person2 != null))
				return false;
	
			return person1.Id.Equals(person2.Id);
		}
	
		public int GetHashCode(Person item)
		{
			return item.Id.GetHashCode();
		}
	}
