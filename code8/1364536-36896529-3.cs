    public class RootObject
    {
        ...
        public void MergeWith(RootObject other)
        {
            if (other.People == null) return;
            if (People == null) People = new List<Person>();
            foreach (Person person in other.People)
            {
                // You may need to make changes here--
                // How do you determine whether two people are the same?
                Person existingPerson = People.FirstOrDefault(p => p.Name == person.Name && 
                                                                   p.Age == person.Age);
                if (existingPerson != null)
                {
                    existingPerson.MergeWith(person);
                }
                else
                {
                    People.Add(person);
                }
            }
        }
    }
