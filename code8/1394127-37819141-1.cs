    public class PersonController : ApiController
    {
        public Person GetPerson()
        {
            Person person = new Person
            {
                FirstName = "Steve",
                LastName = "Rogers",
                DateOfBirth = new DateTime(1920, 7, 4)
            };
            return person;
        }
    }
