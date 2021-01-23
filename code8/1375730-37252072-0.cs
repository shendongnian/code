    using System.Collections.Generic;
    using System.Linq;
    ...
    var predicatesA = new Predicate<Person>[]
        {
            p => p.FirstName.StartsWith("J"),
            p => p.FirstName.EndsWith("e"), 
        };
    var predicatesB = new Predicate<Person>[]
        {
            p => p.FirstName.StartsWith("J"),
            p => p.FirstName.StartsWith("A"), 
        };
    var peopleWithBothOfA = people.Where(p => predicatesA.All(c => c(p)));
    var peopleWithEitherOfB = people.Where(p => predicatesB.Any(c => c(p)));
