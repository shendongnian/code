    public class FakeDb
    {
        public List<Person> Persons
        {
            get
            {
                var persons = new List<Person>();
                for (var i = 0; i < 10; ++i)
                {
                    persons.Add(new Person()
                    {
                        First = "First" + i, 
                        Last = "Last" + i, 
                        PersonID = i
                    });
                }
                return persons; 
            }
        }
    }
