    	public class Chair
		{
			private List<Person> people = new List<Person>();
			public IEnumerable<Person> People { get { return people; } }
			public void AddPerson(Person person)
			{
				people.Add(person);
			}
			public void RemovePerson(Person person)
			{
				people.Remove(person);
			}
			public void ClearPeople(Person person)
			{
				people.Clear();
			}
		}	
		public class Person
		{
			public string Name { get; set; }
		}
