    public class MyCustomListOfPeople : List<Person>
    {
        public override Add(Person person)
        {
            //send email that a person was added or w/e you want to do here
            base.Add(person);
        }
    }
