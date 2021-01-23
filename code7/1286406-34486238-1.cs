	public static class PersonExtensions 
	{
		private Dictionary<Person,List<Person>> compatiblePersons = createCompatiblePersons();
		private static Dictionary<Person,List<Person>> createCompatiblePersons()
		{
			var d = new Dictionary<Person,List<Person>>;
			// put your compatibilities here
			d[Person.John] = new List()
			{
				Person.Kevin, 
				Person.Krystal
			};
			return d;
		}
		
		public static List<Person> GetCompatiblePersons(this Person person)
		{
			return compatiblePersons(person);
		}
		
		public static bool IsCompatibleWith(this Person person, Person other)
		{
			return this.GetCompatiblePersons().Contains(other);
		}
	}
