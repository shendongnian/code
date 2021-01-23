    using System.Linq;
    ...
    public class Person
    {
	    public string FirstName { get; }
	    public string LastName { get; }
    }
    ....
    IEnumerable<Person> people = ...
    var predicatesA = new Predicate<Person>[]
        {
            p => p.FirstName.StartsWith("J"),
            p => p.LastName.EndsWith("e"), 
        };
    var predicatesB = new Predicate<Person>[]
        {
            p => p.FirstName.StartsWith("J"),
            p => p.FirstName.StartsWith("A"), 
        };
    var peopleWithBothOfA = people.Where(p => predicatesA.All(c => c(p)));
    var peopleWithEitherOfB = people.Where(p => predicatesB.Any(c => c(p)));
