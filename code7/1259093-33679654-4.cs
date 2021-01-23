    public class PersonComparer: IEqualityComparer<Persons> 
    {
         public bool Equals(Person x, Person y) {return x.Id == y.Id;}
         public int GetHashCode(Person person) {return person.PersonId.GetHashCode();}
    }
    using(Context c = new Context())
    {
        //get the list of bad guys
        List<Person> badGuys = ...
       var goodPersons = c.Persons.Except(badPersons, PersonComparer()).ToList();
    }
